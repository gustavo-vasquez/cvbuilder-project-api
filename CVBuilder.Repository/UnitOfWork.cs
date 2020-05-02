using System;
using CVBuilder.Domain.Models;
using CVBuilder.Core;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Repositories;
using CVBuilder.Repository.Repositories;

namespace CVBuilder.Repository
{
    public class UnitOfWork : ContextRepository, IUnitOfWork
    {
        private Lazy<IUserRepository> _User;
        private Lazy<ICurriculumRepository> _Curriculum;
        private IPersonalDetailRepository _PersonalDetail;
        private ISectionRepository<StudyDTO,Study> _Study;
        private ISectionRepository<WorkExperienceDTO,WorkExperience> _WorkExperience;
        private ISectionRepository<CertificateDTO,Certificate> _Certificate;
        private ISectionRepository<LanguageDTO,Language> _Language;
        private ISectionRepository<SkillDTO,Skill> _Skill;
        private ISectionRepository<InterestDTO,Interest> _Interest;
        private ISectionRepository<PersonalReferenceDTO,PersonalReference> _PersonalReference;
        private ISectionRepository<CustomSectionDTO,CustomSection> _CustomSection;
        private Lazy<ITemplateRepository> _Template;
        private IRefreshTokenRepository _RefreshToken;

        public UnitOfWork(CVBuilderDbContext context) : base(context)
        {
            _User = new Lazy<IUserRepository>(() =>
            {
                return new UserRepository(_context);
            });

            _Curriculum = new Lazy<ICurriculumRepository>(() =>
            {
                return new CurriculumRepository(_context);
            });

            _Template = new Lazy<ITemplateRepository>(() =>
            {
                return new TemplateRepository(_context);
            });
        }

        public IUserRepository User => _User.Value;
        public ICurriculumRepository Curriculum => _Curriculum.Value;
        public IPersonalDetailRepository PersonalDetail { get { return _PersonalDetail = _PersonalDetail ?? new PersonalDetailRepository(_context); }}
        public ISectionRepository<StudyDTO,Study> Study => _Study = _Study ?? new SectionRepository<StudyDTO, Study>(_context);
        public ISectionRepository<WorkExperienceDTO,WorkExperience> WorkExperience => _WorkExperience = _WorkExperience ?? new SectionRepository<WorkExperienceDTO,WorkExperience>(_context);
        public ISectionRepository<CertificateDTO,Certificate> Certificate => _Certificate = _Certificate ?? new SectionRepository<CertificateDTO,Certificate>(_context);
        public ISectionRepository<LanguageDTO,Language> Language => _Language = _Language ?? new SectionRepository<LanguageDTO,Language>(_context);
        public ISectionRepository<SkillDTO,Skill> Skill => _Skill = _Skill ?? new SectionRepository<SkillDTO,Skill>(_context);
        public ISectionRepository<InterestDTO,Interest> Interest => _Interest = _Interest ?? new SectionRepository<InterestDTO,Interest>(_context);
        public ISectionRepository<PersonalReferenceDTO,PersonalReference> PersonalReference => _PersonalReference = _PersonalReference ?? new SectionRepository<PersonalReferenceDTO,PersonalReference>(_context);
        public ISectionRepository<CustomSectionDTO,CustomSection> CustomSection => _CustomSection = _CustomSection ?? new SectionRepository<CustomSectionDTO,CustomSection>(_context);
        public ITemplateRepository Template => _Template.Value;
        public IRefreshTokenRepository RefreshToken => _RefreshToken = _RefreshToken ?? new RefreshTokenRepository(_context);
    }
}