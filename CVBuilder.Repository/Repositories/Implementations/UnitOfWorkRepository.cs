using System;
using CVBuilder.Domain.Models;
using CVBuilder.Repository.DTOs;
using CVBuilder.Repository.Repositories.Interfaces;

namespace CVBuilder.Repository.Repositories.Implementations
{
    public class UnitOfWorkRepository : ContextRepository, IUnitOfWorkRepository
    {
        private Lazy<ICurriculumRepository> _Curriculum;
        private IPersonalDetailRepository _PersonalDetail;
        private IRepository<StudyDTO,Study> _Study;
        private IRepository<WorkExperienceDTO,WorkExperience> _WorkExperience;
        private IRepository<CertificateDTO,Certificate> _Certificate;
        private IRepository<LanguageDTO,Language> _Language;
        private IRepository<SkillDTO,Skill> _Skill;
        private IRepository<InterestDTO,Interest> _Interest;
        private IRepository<PersonalReferenceDTO,PersonalReference> _PersonalReference;
        private IRepository<CustomSectionDTO,CustomSection> _CustomSection;
        private Lazy<ITemplateRepository> _Template;

        public UnitOfWorkRepository(CVBuilderDbContext context) : base(context)
        {
            _Curriculum = new Lazy<ICurriculumRepository>(() =>
            {
                return new CurriculumRepository(_context);
            });

            _Template = new Lazy<ITemplateRepository>(() =>
            {
                return new TemplateRepository(_context);
            });
        }

        public ICurriculumRepository Curriculum => _Curriculum.Value;
        public IPersonalDetailRepository PersonalDetail { get { return _PersonalDetail = _PersonalDetail ?? new PersonalDetailRepository(_context); }}
        public IRepository<StudyDTO,Study> Study => _Study = _Study ?? new Repository<StudyDTO, Study>(_context);
        public IRepository<WorkExperienceDTO,WorkExperience> WorkExperience => _WorkExperience = _WorkExperience ?? new Repository<WorkExperienceDTO,WorkExperience>(_context);
        public IRepository<CertificateDTO,Certificate> Certificate => _Certificate = _Certificate ?? new Repository<CertificateDTO,Certificate>(_context);
        public IRepository<LanguageDTO,Language> Language => _Language = _Language ?? new Repository<LanguageDTO,Language>(_context);
        public IRepository<SkillDTO,Skill> Skill => _Skill = _Skill ?? new Repository<SkillDTO,Skill>(_context);
        public IRepository<InterestDTO,Interest> Interest => _Interest = _Interest ?? new Repository<InterestDTO,Interest>(_context);
        public IRepository<PersonalReferenceDTO,PersonalReference> PersonalReference => _PersonalReference = _PersonalReference ?? new Repository<PersonalReferenceDTO,PersonalReference>(_context);
        public IRepository<CustomSectionDTO,CustomSection> CustomSection => _CustomSection = _CustomSection ?? new Repository<CustomSectionDTO,CustomSection>(_context);
        public ITemplateRepository Template => _Template.Value;
    }
}