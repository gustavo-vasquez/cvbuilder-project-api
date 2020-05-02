using CVBuilder.Core.DTOs;
using CVBuilder.Core.Repositories;
using CVBuilder.Domain.Models;

namespace CVBuilder.Core
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        ICurriculumRepository Curriculum { get; }
        IPersonalDetailRepository PersonalDetail { get; }
        ISectionRepository<StudyDTO,Study> Study { get; }
        ISectionRepository<WorkExperienceDTO,WorkExperience> WorkExperience { get; }
        ISectionRepository<CertificateDTO,Certificate> Certificate { get; }
        ISectionRepository<LanguageDTO,Language> Language { get; }
        ISectionRepository<SkillDTO,Skill> Skill { get; }
        ISectionRepository<InterestDTO,Interest> Interest { get; }
        ISectionRepository<PersonalReferenceDTO,PersonalReference> PersonalReference { get; }
        ISectionRepository<CustomSectionDTO,CustomSection> CustomSection { get; }
        ITemplateRepository Template { get; }
        IRefreshTokenRepository RefreshToken { get; }
    }
}