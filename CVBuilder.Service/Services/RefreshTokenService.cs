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

        public void Create(int userId, string token, int expiryDate)
        {
            _UnitOfWork.RefreshToken.Create(userId, token, expiryDate);
        }
    }
}