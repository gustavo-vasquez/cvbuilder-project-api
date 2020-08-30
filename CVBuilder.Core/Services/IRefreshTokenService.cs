namespace CVBuilder.Core.Services
{
    public interface IRefreshTokenService
    {
        void Create(int userId, string token, System.DateTime accessDate, int expiryDate);
    }
}