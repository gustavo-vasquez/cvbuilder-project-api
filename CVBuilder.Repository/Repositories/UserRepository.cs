using System.Linq;
using CVBuilder.Domain.Models;
using CVBuilder.Repository.Automapper;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Repositories;

namespace CVBuilder.Repository.Repositories
{
    public class UserRepository : ContextRepository, IUserRepository
    {
        public UserRepository(CVBuilderDbContext context) : base(context)
        {
        }

        public int Create(RegisterDTO dto)
        {
            if(!_context.Users.Any(u => u.Email == dto.Email)) {
                User newUser = Mapping.Mapper.Map<RegisterDTO,User>(dto);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return newUser.UserId;
            }
            else
                throw new System.ArgumentException("Ya existe un usuario registrado con el correo " + dto.Email + ".");
        }

        public bool IsValidUser(string email, string password, out UserDTO dto, out int userId, System.DateTime accessDate)
        {
            User user = _context.Users.Where(u => u.Email == email && u.Password == password).SingleOrDefault();

            if (user != null)
            {
                int curriculumId = _context.Curriculum.Where(c => c.Id_User == user.UserId).SingleOrDefault().CurriculumId;
                var personalDetail = _context.PersonalDetails.Where(d => d.Id_Curriculum == curriculumId).SingleOrDefault();
                
                dto = Mapping.Mapper.Map<User,UserDTO>(user, opts =>
                {
                    opts.Items["AccessDate"] = accessDate;
                    opts.Items["PhotoArray"] = personalDetail.Photo;
                    opts.Items["PhotoMimeType"] = personalDetail.PhotoMimeType;
                });
                userId = user.UserId;

                return true;
            }
            else
            {
                dto = null;
                userId = 0;
                return false;
            }   
        }

        public int GetUserIdByEmail(string email)
        {
            User entity = _context.Users.SingleOrDefault(t => t.Email == email);
            return entity != null ? entity.UserId : 0;
        }
    }
}