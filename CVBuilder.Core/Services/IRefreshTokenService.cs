namespace CVBuilder.Core.Services
{
    public interface IRefreshTokenService
    {
        void Create(int userId, string token, int expiryDate);
    }
}