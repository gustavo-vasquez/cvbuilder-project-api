using System.Linq;
using CVBuilder.Domain.Models;
using CVBuilder.Repository.Repositories.Interfaces;

namespace CVBuilder.Repository.Repositories.Implementations
{
    public class TemplateRepository : ContextRepository, ITemplateRepository
    {
        /* private readonly CVBuilderDbContext _context;

        public TemplateRepository(CVBuilderDbContext context)
        {
            _context = context;
        } */
        public TemplateRepository(CVBuilderDbContext context) : base (context)
        {
        }

        public Template GetByUserId(int userId)
        {
            Template template = (from tem in _context.Templates
                                join cv in _context.Curriculum
                                on tem.TemplateId equals cv.Id_Template
                                where cv.Id_User == userId
                                select tem).SingleOrDefault();

            if (template != null)
                return template;
            else
                return _context.Templates.Find(1);
        }

        public string GetPreviewPath(int userId)
        {   
            return GetByUserId(userId).Path;
        }

        public void ChangeTemplate(string path, int curriculumId, int userId)
        {
            Template template = _context.Templates.SingleOrDefault(t => t.Path == path);

            if (template != null)
            {
                Curriculum curriculum = _context.Curriculum.Single(c => c.CurriculumId == curriculumId && c.Id_User == userId);
                curriculum.Id_Template = template.TemplateId;
                _context.SaveChanges();
            }
        }
    }
}