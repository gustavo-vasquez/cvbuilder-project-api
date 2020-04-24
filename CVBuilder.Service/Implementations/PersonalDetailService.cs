using CVBuilder.Repository.DTOs;
using CVBuilder.Repository.Repositories.Interfaces;
using CVBuilder.Service.Interfaces;

namespace CVBuilder.Service.Implementations
{
    public class PersonalDetailService : UnitOfWork, IPersonalDetailService
    {
        public PersonalDetailService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
        }

        public int Create(PersonalDetailDTO dto)
        {
            return _UnitOfWork.PersonalDetail.Create(dto);
        }

        public int Update(PersonalDetailDTO dto)
        {
            return _UnitOfWork.PersonalDetail.Update(dto);
        }

        public PersonalDetailDTO GetByCurriculumId(int curriculumId)
        {
            PersonalDetailDTO dto = _UnitOfWork.PersonalDetail.GetByCurriculumId(curriculumId);
            
            if (dto != null)
                return dto;

            return null;
        }
    }
}