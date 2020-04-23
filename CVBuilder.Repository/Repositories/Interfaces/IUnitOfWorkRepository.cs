using System;
using CVBuilder.Domain.Models;
using CVBuilder.Repository.DTOs;

namespace CVBuilder.Repository.Repositories.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        ICurriculumRepository Curriculum { get; }
        IPersonalDetailRepository PersonalDetail { get; }
        IRepository<StudyDTO,Study> Study { get; }
        IRepository<WorkExperienceDTO,WorkExperience> WorkExperience { get; }
        IRepository<CertificateDTO,Certificate> Certificate { get; }
        IRepository<LanguageDTO,Language> Language { get; }
        IRepository<SkillDTO,Skill> Skill { get; }
        IRepository<InterestDTO,Interest> Interest { get; }
        IRepository<PersonalReferenceDTO,PersonalReference> PersonalReference { get; }
        IRepository<CustomSectionDTO,CustomSection> CustomSection { get; }
        ITemplateRepository Template { get; }
    }
}