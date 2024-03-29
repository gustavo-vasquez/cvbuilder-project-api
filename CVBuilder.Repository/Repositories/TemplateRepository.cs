using System.Linq;
using CVBuilder.Domain.Models;
using CVBuilder.Repository.Automapper;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Repositories;

namespace CVBuilder.Repository.Repositories
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
                                select tem).FirstOrDefault();

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
                                select tem).FirstOrDefault();

            return template != null ? template.Path : "/img/templates/classic.png";
        }

        public string ChangeTemplate(string path, int curriculumId)
        {
            Template template = _context.Templates.FirstOrDefault(t => t.Path == path);

            if (template != null)
            {
                Curriculum curriculum = _context.Curriculum.Find(curriculumId);
                curriculum.Id_Template = template.TemplateId;
                _context.SaveChanges();

                return template.Name;
            }

            return null;
        }
    }
}