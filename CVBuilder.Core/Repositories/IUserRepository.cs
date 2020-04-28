using CVBuilder.Core.DTOs;

namespace CVBuilder.Core.Repositories
{
    public interface IUserRepository
    {
        int Create(UserDTO dto);
        bool CheckByEmailAndPassword(string email, string password, out UserDTO dto);
    }
}