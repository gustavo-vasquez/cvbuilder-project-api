using System;
using CVBuilder.Domain.Models;

namespace CVBuilder.Repository.Repositories.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        ICurriculumRepository Curriculum { get; }
        IPersonalDetailRepository PersonalDetail { get; set; }
        IRepository<Study> Study { get; }
        IRepository<WorkExperience> WorkExperience { get; }
        IRepository<Certificate> Certificate { get; }
        IRepository<Language> Language { get; }
        IRepository<Skill> Skill { get; }
        IRepository<Interest> Interest { get; }
        IRepository<PersonalReference> PersonalReference { get; }
        IRepository<CustomSection> CustomSection { get; }
        ITemplateRepository Template { get; }
    }
}