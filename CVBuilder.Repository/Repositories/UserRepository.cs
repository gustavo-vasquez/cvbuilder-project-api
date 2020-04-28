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

        public int Create(UserDTO dto)
        {
            User newUser = Mapping.Mapper.Map<UserDTO,User>(dto);
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser.UserId;
        }

        public bool CheckByEmailAndPassword(string email, string password, out UserDTO dto)
        {
            User user = _context.Users.Where(u => u.Email == email && u.Password == password).SingleOrDefault();

            if (user != null)
            {
                int curriculumId = _context.Curriculum.Where(c => c.Id_User == user.UserId).SingleOrDefault().CurriculumId;
                var personalDetail = _context.PersonalDetails.Where(d => d.Id_Curriculum == curriculumId).SingleOrDefault();
                
                dto = Mapping.Mapper.Map<User,UserDTO>(user, opts =>
                {
                    opts.Items["PhotoArray"] = personalDetail.Photo;
                    opts.Items["PhotoMimeType"] = personalDetail.PhotoMimeType;
                });

                return true;
            }
            else
            {
                dto = null;
                return false;
            }
                
        }
    }
}