namespace CVBuilder.Core.Repositories
{
    public interface IRefreshTokenRepository
    {
        void Create(int userId, string token, System.DateTime accessDate, int expiryDate);
        void Update(int userId, string oldRefreshToken, string newRefreshToken, System.DateTime accessDate, int expiryDate);
        void Delete(int userId, string token);
        string GetByUserId(int userId, string refreshToken);
    }
}