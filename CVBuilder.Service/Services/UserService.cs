using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CVBuilder.Core;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Helpers;
using CVBuilder.Core.Services;
using CVBuilder.Service.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CVBuilder.Service.Services
{
    public class UserService : IUserService
    {
        protected readonly IUnitOfWork _UnitOfWork;
        private readonly TokenManagement _tokenManagement;

        public UserService(IUnitOfWork unitOfWork, IOptions<TokenManagement> tokenManagement)
        {
            _UnitOfWork = unitOfWork;
            _tokenManagement = tokenManagement.Value;
        }

        public int Create(RegisterDTO dto)
        {
            int newUserId = _UnitOfWork.User.Create(dto);
            int newCurriculumId = _UnitOfWork.Curriculum.Create(newUserId);
            _UnitOfWork.PersonalDetail.Create(new PersonalDetailDTO()
            {
                Name = "",
                LastName = "",
                Email = "",
                Summary = "",
                SummaryIsVisible = true,
                Id_Curriculum = newCurriculumId
            });

            return 1;
        }

        public bool IsAuthenticated(string email, string password, out UserDTO userInfo)
        {
            int userId;
            DateTime accessDate = DateTime.Now;

            if (!_UnitOfWork.User.IsValidUser(email, password, out userInfo, out userId, accessDate))
                return false;
            
            IEnumerable<Claim> claims = new[]
            {
                new Claim(JwtUserClaims.EMAIL_ADDRESS, userInfo.Email),
                new Claim(JwtUserClaims.PHOTO, userInfo.Photo),
                new Claim(JwtUserClaims.ACCESS_DATE, userInfo.AccessDate)
            };

            userInfo.Token = this.GenerateToken(userId, claims, accessDate);
            userInfo.RefreshToken = this.GenerateRefreshToken(userId, _tokenManagement.RefreshExpiration);

            return true;
        }

        public ExchangeTokenDTO ExchangeToken(string token, string refreshToken)
        {
            ClaimsPrincipal claimsPrincipal = this.GetClaimsFromExpiredToken(token);
            string email = claimsPrincipal.FindFirstValue(JwtUserClaims.EMAIL_ADDRESS);
            int userId = _UnitOfWork.User.GetUserIdByEmail(email);
            string savedRefreshToken = this.GetRefreshToken(userId, email);
            
            if (savedRefreshToken != refreshToken)
                throw new SecurityTokenException("Token de renovación expirado/incorrecto. Vuelva a iniciar sesión.");

            IEnumerable<Claim> claimsCopied = new []
            {
                 new Claim(JwtUserClaims.EMAIL_ADDRESS, email),
                 new Claim(JwtUserClaims.PHOTO, claimsPrincipal.FindFirstValue(JwtUserClaims.PHOTO)),
                 new Claim(JwtUserClaims.ACCESS_DATE, claimsPrincipal.FindFirstValue(JwtUserClaims.ACCESS_DATE))
            };
            string newToken = this.GenerateToken(userId, claimsCopied, DateTime.Now);
            string newRefreshToken = this.GenerateRefreshToken(userId, _tokenManagement.RefreshExpiration);
            _UnitOfWork.RefreshToken.Delete(refreshToken);

            return new ExchangeTokenDTO() { Token = newToken, RefreshToken = newRefreshToken };
        }

        private string GenerateToken(int userId, IEnumerable<Claim> claims, DateTime expiryDate)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _tokenManagement.Issuer,
                _tokenManagement.Audience,
                claims,
                expires: expiryDate.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        private string GenerateRefreshToken(int userId, int expiryDate)
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                string refreshToken = Convert.ToBase64String(randomNumber);
                _UnitOfWork.RefreshToken.Create(userId, refreshToken, expiryDate);

                return refreshToken;
            }
        }

        private ClaimsPrincipal GetClaimsFromExpiredToken(string expiredToken)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _tokenManagement.Issuer,
                ValidAudience = _tokenManagement.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret)),
                ValidateLifetime = false
            };

            SecurityToken securityToken;
            var allClaims = new JwtSecurityTokenHandler().ValidateToken(expiredToken, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Token incorrecto.");

            return allClaims;
        }

        private string GetRefreshToken(int userId, string email)
        {
            return userId != 0 ? _UnitOfWork.RefreshToken.GetByUserId(userId) : null;
        }
    }
}