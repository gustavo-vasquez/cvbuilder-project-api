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
    }
}