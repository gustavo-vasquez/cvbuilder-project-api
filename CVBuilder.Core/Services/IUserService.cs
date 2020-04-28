using CVBuilder.Core.DTOs;

namespace CVBuilder.Core.Services
{
    public interface IUserService
    {
        int Create(UserDTO dto);
        bool IsAuthenticated(string email, string password, out UserDTO userInfo);
    }
}