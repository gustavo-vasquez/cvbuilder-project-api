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

        public void Create(int userId, string token, int expiryDate)
        {
            DateTime now = DateTime.Now;

            _context.RefreshTokens.Add(new RefreshToken()
            {
                Token = token,
                CreationDate = now,
                ExpiryDate = now.AddMinutes(expiryDate),
                Id_User = userId
            });
            _context.SaveChanges();
        }

        public void Delete(string token)
        {
            RefreshToken entity = _context.RefreshTokens.Single(t => t.Token == token);
            _context.RefreshTokens.Remove(entity);
            _context.SaveChanges();
        }

        public string GetByUserId(int userId, string refreshToken)
        {
            RefreshToken entity = _context.RefreshTokens.SingleOrDefault(t => t.Id_User == userId && t.Token == refreshToken && t.ExpiryDate > DateTime.Now);
            return entity != null ? entity.Token : null;
        }
    }
}