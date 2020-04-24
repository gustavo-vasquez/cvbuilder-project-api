using CVBuilder.Repository.DTOs;
using CVBuilder.Repository.Repositories.Interfaces;
using CVBuilder.Service.Interfaces;

namespace CVBuilder.Service.Implementations
{
    public class CurriculumService : UnitOfWork, ICurriculumService
    {
        public CurriculumService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
        }

        public int Create(int userId)
        {
            return _UnitOfWork.Curriculum.Create(userId);
        }

        public int GetByUserId(int userId)
        {
            return _UnitOfWork.Curriculum.GetByUserId(userId);
        }

        public FinishedDTO GetCurriculumContent(int userId, int curriculumId)
        {
            return new FinishedDTO()
            {
                PersonalDetails = _UnitOfWork.PersonalDetail.GetByCurriculumId(curriculumId),
                Studies = _UnitOfWork.Study.GetAllVisible(curriculumId),
                WorkExperiences = _UnitOfWork.WorkExperience.GetAllVisible(curriculumId),
                Certificates = _UnitOfWork.Certificate.GetAllVisible(curriculumId),
                PersonalReferences = _UnitOfWork.PersonalReference.GetAllVisible(curriculumId),
                Languages = _UnitOfWork.Language.GetAllVisible(curriculumId),
                Skills = _UnitOfWork.Skill.GetAllVisible(curriculumId),
                Interests = _UnitOfWork.Interest.GetAll(curriculumId),
                CustomSections = _UnitOfWork.CustomSection.GetAllVisible(curriculumId),
                Templates = _UnitOfWork.Template.GetByUserId(userId),
                SectionVisibility = _UnitOfWork.Curriculum.GetIsVisibleStates(curriculumId)
            };
        }
    }
}