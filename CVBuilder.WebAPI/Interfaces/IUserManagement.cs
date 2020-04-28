using CVBuilder.WebAPI.Models.Authentication;

namespace CVBuilder.WebAPI.Interfaces
{
    public interface IUserManagement
    {
        bool IsValidUser(string email, string password, UserResponse userInfo);
    }
}