using CVBuilder.Core.DTOs;

namespace CVBuilder.Core.Services
{
    public interface IUserService
    {
        void Create(RegisterDTO dto);
        bool IsAuthenticated(string email, string password, out UserDTO userInfo);
        ExchangeTokenDTO ExchangeToken(string token, string refreshToken);
        bool CurrentTokenIsValid(string token);
    }
}