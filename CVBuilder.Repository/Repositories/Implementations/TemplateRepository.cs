using System.Linq;
using CVBuilder.Domain.Models;
using CVBuilder.Repository.Automapper;
using CVBuilder.Repository.DTOs;
using CVBuilder.Repository.Repositories.Interfaces;

namespace CVBuilder.Repository.Repositories.Implementations
{
    public class TemplateRepository : ContextRepository, ITemplateRepository
    {
        public TemplateRepository(CVBuilderDbContext context) : base (context)
        {
        }

        public TemplateDTO GetByUserId(int userId)
        {
            Template template = (from tem in _context.Templates
                                join cv in _context.Curriculum
                                on tem.TemplateId equals cv.Id_Template
                                where cv.Id_User == userId
                                select tem).SingleOrDefault();

            if (template != null)
                return Mapping.Mapper.Map<Template,TemplateDTO>(template);
            else
                return Mapping.Mapper.Map<Template,TemplateDTO>(_context.Templates.Find(1));
        }

        public string GetPreviewPath(int userId)
        {
            Template template = (from tem in _context.Templates
                                join cv in _context.Curriculum
                                on tem.TemplateId equals cv.Id_Template
                                where cv.Id_User == userId
                                select tem).SingleOrDefault();

            if (template != null)
                return template.Path;
            else
                return "/img/templates/classic.png";
        }

        public void ChangeTemplate(string path, int curriculumId, int userId)
        {
            Template template = _context.Templates.SingleOrDefault(t => t.Path == path);

            if (template != null)
            {
                Curriculum curriculum = _context.Curriculum.SingleOrDefault(c => c.CurriculumId == curriculumId && c.Id_User == userId);

                if(curriculum != null)
                {
                    curriculum.Id_Template = template.TemplateId;
                    _context.SaveChanges();
                }
            }
        }
    }
}