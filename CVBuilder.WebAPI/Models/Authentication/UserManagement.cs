using CVBuilder.WebAPI.Interfaces;

namespace CVBuilder.WebAPI.Models.Authentication
{
    public class UserManagement : IUserManagement
    {
        public bool IsValidUser(string userName, string password, UserResponse userInfo)
        {
            return true; // realizar validaciones
        }
    }
}