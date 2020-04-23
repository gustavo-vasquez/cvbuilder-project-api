using System.Linq;
using CVBuilder.Domain.Models;
using CVBuilder.Repository.Automapper;
using CVBuilder.Repository.DTOs;
using CVBuilder.Repository.Repositories.Interfaces;

namespace CVBuilder.Repository.Repositories.Implementations
{
    public class PersonalDetailRepository : ContextRepository, IPersonalDetailRepository
    {
        public PersonalDetailRepository(CVBuilderDbContext context) : base(context)
        {
        }

        public int Create(PersonalDetailDTO data)
        {
            // validar después el tamaño de la foto de perfil en la capa de servicios
            _context.PersonalDetails.Add(Mapping.Mapper.Map<PersonalDetailDTO,PersonalDetail>(data));
            return _context.SaveChanges();
        }

        public int Update(PersonalDetailDTO data)
        {
            // validar después el tamaño de la foto de perfil en la capa de servicios
            _context.PersonalDetails.Update(Mapping.Mapper.Map<PersonalDetailDTO,PersonalDetail>(data));
            return _context.SaveChanges();
        }

        public PersonalDetailDTO GetByCurriculumId(int curriculumId)
        {
            PersonalDetail row = _context.PersonalDetails.Where(p => p.Id_Curriculum == curriculumId).FirstOrDefault();
            return Mapping.Mapper.Map<PersonalDetail,PersonalDetailDTO>(row);
        }
    }
}