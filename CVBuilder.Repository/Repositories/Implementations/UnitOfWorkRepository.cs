using CVBuilder.Domain.Models;
using CVBuilder.Repository.Repositories.Interfaces;

namespace CVBuilder.Repository.Repositories.Implementations
{
    public class UnitOfWorkRepository : ContextRepository, IUnitOfWorkRepository
    {
        public UnitOfWorkRepository(CVBuilderDbContext context) : base(context)
        {
            this.Curriculum = new CurriculumRepository(_context);
            this.Study = new Repository<Study>(_context);
            this.WorkExperience = new Repository<WorkExperience>(_context);
            this.Certificate = new Repository<Certificate>(_context);
            this.Language = new Repository<Language>(_context);
            this.Skill = new Repository<Skill>(_context);
            this.Interest = new Repository<Interest>(_context);
            this.PersonalReference = new Repository<PersonalReference>(_context);
            this.CustomSection = new Repository<CustomSection>(_context);
            this.Template = new TemplateRepository(_context);
        }

        public ICurriculumRepository Curriculum { get; set; }
        public IPersonalDetailRepository PersonalDetail { get; set; }
        public IRepository<Study> Study { get; set; }
        public IRepository<WorkExperience> WorkExperience { get; set; }
        public IRepository<Certificate> Certificate { get; set; }
        public IRepository<Language> Language { get; set; }
        public IRepository<Skill> Skill { get; set; }
        public IRepository<Interest> Interest { get; set; }
        public IRepository<PersonalReference> PersonalReference { get; set; }
        public IRepository<CustomSection> CustomSection { get; set; }
        public ITemplateRepository Template { get; set; }
    }
}