using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CVBuilder.WebAPI.Helpers.Enums;
using CVBuilder.WebAPI.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CVBuilder.WebAPI.Models.Authentication
{
    public class TokenAuthentication : IAuthenticate
    {
        private readonly IUserManagement _userManagement;
        private readonly TokenManagement _tokenManagement;
        
        public TokenAuthentication(IUserManagement userManagement, IOptions<TokenManagement> tokenManagement)
        {
            _userManagement = userManagement;
            _tokenManagement = tokenManagement.Value;
        }

        public bool IsAuthenticated(UserRequest login, out UserResponse userInfo)
        {
            if (!_userManagement.IsValidUser(login.Email, login.Password, userInfo = new UserResponse()))
                return false;
            
            var claim = new[]
            {
                new Claim(UserClaims.EMAIL, userInfo.Email),
                new Claim(UserClaims.PHOTO, userInfo.Photo),
                new Claim(UserClaims.ACCESSDATE, userInfo.AccessDate)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_tokenManagement.Secret));
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
    }
}