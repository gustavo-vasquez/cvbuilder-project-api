using System.Linq;
using CVBuilder.Domain.Models;
using CVBuilder.Repository.Automapper;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Repositories;

namespace CVBuilder.Repository.Repositories
{
    public class CurriculumRepository : ContextRepository, ICurriculumRepository
    {
        public CurriculumRepository(CVBuilderDbContext context) : base (context)
        {
        }

        public int Create(int userId)
        {
            Curriculum entity = new Curriculum()
            {
                CertificatesIsVisible = true,
                CustomSectionsIsVisible = true,
                InterestsIsVisible = true,
                LanguagesIsVisible = true,
                PersonalReferencesIsVisible = true,
                SkillsIsVisible = true,
                WorkExperiencesIsVisible = true,
                Id_User = userId,
                Id_Template = 1
            };

            _context.Curriculum.Add(entity);
            _context.SaveChanges();

            return entity.CurriculumId;
        }

        public int GetIdByUserId(int userId)
        {
            return _context.Curriculum.SingleOrDefault(c => c.Id_User == userId).CurriculumId;
        }

        public CurriculumDTO GetById(int curriculumId)
        {
            Curriculum entity = _context.Curriculum.SingleOrDefault(c => c.CurriculumId == curriculumId);
            return Mapping.Mapper.Map<Curriculum,CurriculumDTO>(entity);
        }

        public SectionVisibilityDTO GetIsVisibleStates(int curriculumId)
        {
            Curriculum entity = _context.Curriculum.SingleOrDefault(c => c.CurriculumId == curriculumId);
            return Mapping.Mapper.Map<Curriculum,SectionVisibilityDTO>(entity);
        }
    }
}