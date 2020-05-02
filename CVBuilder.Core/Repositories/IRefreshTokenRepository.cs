namespace CVBuilder.Core.Repositories
{
    public interface IRefreshTokenRepository
    {
        void Create(int userId, string token, int expiryDate);
        void Delete(string token);
        string GetByUserId(int userId);
    }
}