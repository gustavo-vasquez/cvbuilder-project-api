using CVBuilder.Core.DTOs;

namespace CVBuilder.Core.Repositories
{
    public interface IUserRepository
    {
        int Create(RegisterDTO dto);
        bool IsValidUser(string email, string password, out UserDTO dto, out int userId, System.DateTime accessDate);
        int GetUserIdByEmail(string email);
    }
}