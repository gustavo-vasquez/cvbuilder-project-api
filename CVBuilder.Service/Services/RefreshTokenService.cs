using CVBuilder.Core;
using CVBuilder.Core.Services;

namespace CVBuilder.Service.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        protected readonly IUnitOfWork _UnitOfWork;

        public RefreshTokenService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public void Create(int userId, string token, System.DateTime accessDate, int expiryDate)
        {
            _UnitOfWork.RefreshToken.Create(userId, token, accessDate, expiryDate);
        }

        public void Update(int userId, string oldRefreshToken, string newRefreshToken, System.DateTime accessDate, int expiryDate)
        {
            _UnitOfWork.RefreshToken.Update(userId, oldRefreshToken, newRefreshToken, accessDate, expiryDate);
        }

        public void Delete(int userId, string token)
        {
            _UnitOfWork.RefreshToken.Delete(userId, token);
        }
    }
}