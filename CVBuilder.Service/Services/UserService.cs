using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CVBuilder.Core;
using CVBuilder.Core.DTOs;
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

        public int Create(UserDTO dto)
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

        /* public bool IsValidUser(string userName, string password, out UserDTO dto)
        {
            var user = _UnitOfWork.User.GetByEmailAndPassword(userName, password, out dto);
            return true;
        } */

        public bool IsAuthenticated(string email, string password, out UserDTO userInfo)
        {
            if (!_UnitOfWork.User.CheckByEmailAndPassword(email, password, out userInfo))
                return false;
            
            var claim = new[]
            {
                new Claim(UserClaims.EMAIL, userInfo.Email),
                new Claim(UserClaims.PHOTO, userInfo.Photo),
                new Claim(UserClaims.ACCESSDATE, userInfo.AccessDate)
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _tokenManagement.Issuer,
                _tokenManagement.Audience,
                claim,
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );

            userInfo.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return true;
        }

        // Validar token manualmente
        /* public bool ValidateToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(_tokenManagement.Secret));
            var tokenHandler = new JwtSecurityTokenHandler();

            try
	        {
                var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _tokenManagement.Issuer,
                    ValidAudience = _tokenManagement.Audience,
                    IssuerSigningKey = securityKey
                }, out SecurityToken validatedToken);
	        }
            catch
	        {
		        return false;
            }
            //catch(SecurityTokenValidationException ex)
            //{
            //    throw new System.Exception($"Error al validar el token: {ex.Message}");
            //}
	        
            return true;
        } */

        // Obtener campos específicos del token via Claims
        /* public string GetClaim(string token, string claimType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
	        var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

	        var stringClaimValue = securityToken.Claims.First(claim => claim.Type == claimType).Value;
	        
            return stringClaimValue;
        } */
    }
}