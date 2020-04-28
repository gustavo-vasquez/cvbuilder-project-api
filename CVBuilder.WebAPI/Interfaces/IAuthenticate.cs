using CVBuilder.WebAPI.Models.Authentication;

namespace CVBuilder.WebAPI.Interfaces
{
    interface IAuthenticate
    {
        bool IsAuthenticated(UserRequest login, out UserResponse userInfo);
    }
}