using CVBuilder.Domain.Models;
using CVBuilder.Repository.Repositories.Interfaces;

namespace CVBuilder.Repository.Repositories.Implementations
{
    public class PersonalDetailRepository : ContextRepository, IPersonalDetailRepository
    {
        public PersonalDetailRepository(CVBuilderDbContext context) : base(context)
        {
        }

        public int Create(PersonalDetail data)
        {
            // validar después la foto de perfil en la capa de servicios
            _context.PersonalDetails.Add(data);
            return _context.SaveChanges();
        }

        public int Update(PersonalDetail data, int curriculumId)
        {
            // validar después la foto de perfil en la capa de servicios
            _context.PersonalDetails.Update(data);
            return _context.SaveChanges();
        }

        public PersonalDetail GetByCurriculumId(int curriculumId)
        {
            throw new System.NotImplementedException();
        }
    }
}