using System.Linq;
using CVBuilder.Domain.Models;
using CVBuilder.Repository.Automapper;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Repositories;

namespace CVBuilder.Repository.Repositories
{
    public class PersonalDetailRepository : ContextRepository, IPersonalDetailRepository
    {
        public PersonalDetailRepository(CVBuilderDbContext context) : base(context)
        {
        }

        public int Create(PersonalDetailDTO data)
        {
            if(!_context.PersonalDetails.Any(d => d.Id_Curriculum == data.Id_Curriculum))
            {
                _context.PersonalDetails.Add(Mapping.Mapper.Map<PersonalDetailDTO,PersonalDetail>(data));
                return _context.SaveChanges();
            }
            else
                return 0;
        }

        public int Update(PersonalDetailDTO data)
        {
            PersonalDetail dataToUpdate = Mapping.Mapper.Map<PersonalDetailDTO,PersonalDetail>(data);
            _context.PersonalDetails.Update(dataToUpdate);
            if(dataToUpdate.Photo.Length == 0 || dataToUpdate.PhotoMimeType == null)
            {
                _context.Entry(dataToUpdate).Property(x => x.Photo).IsModified = false;
                _context.Entry(dataToUpdate).Property(x => x.PhotoMimeType).IsModified = false;
            }

            return _context.SaveChanges();
        }

        public PersonalDetailDTO GetByCurriculumId(int curriculumId)
        {
            PersonalDetail entity = _context.PersonalDetails.Where(p => p.Id_Curriculum == curriculumId).FirstOrDefault();
            return entity != null ? Mapping.Mapper.Map<PersonalDetail,PersonalDetailDTO>(entity) : null;
        }
    }
}