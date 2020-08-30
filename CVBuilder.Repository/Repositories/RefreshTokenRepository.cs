using System;
using System.Linq;
using CVBuilder.Core.Repositories;
using CVBuilder.Domain.Models;

namespace CVBuilder.Repository.Repositories
{
    public class RefreshTokenRepository : ContextRepository, IRefreshTokenRepository
    {
        public RefreshTokenRepository(CVBuilderDbContext context) : base(context)
        {
        }

        public void Create(int userId, string token, DateTime accessDate, int expiryDate)
        {
            _context.RefreshTokens.Add(new RefreshToken()
            {
                Token = token,
                CreationDate = accessDate,
                ExpiryDate = accessDate.AddMinutes(expiryDate),
                Id_User = userId
            });

            _context.SaveChanges();
        }

        public void Update(int userId, string oldRefreshToken, string newRefreshToken, DateTime accessDate, int expiryDate)
        {
            try
            {
                RefreshToken currentRefreshToken = _context.RefreshTokens.Single(r => r.Token == oldRefreshToken && r.Id_User == userId);
                currentRefreshToken.Token = newRefreshToken;
                currentRefreshToken.CreationDate = accessDate;
                currentRefreshToken.ExpiryDate = accessDate.AddMinutes(expiryDate);

                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int userId, string token)
        {
            RefreshToken entity = _context.RefreshTokens.SingleOrDefault(t => t.Id_User == userId && t.Token == token);

            if(entity != null)
            {
                _context.RefreshTokens.Remove(entity);
                _context.SaveChanges();
            }
            else
                throw new ArgumentException("El token de refresco no existe o ya ha sido eliminado.");
        }

        public string GetByUserId(int userId, string refreshToken)
        {
            RefreshToken entity = _context.RefreshTokens.SingleOrDefault(t => t.Id_User == userId && t.Token == refreshToken && t.ExpiryDate > DateTime.Now);
            return entity != null ? entity.Token : null;
        }
    }
}