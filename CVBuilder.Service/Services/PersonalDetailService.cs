using CVBuilder.Core;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Services;

namespace CVBuilder.Service.Services
{
    public class PersonalDetailService : IPersonalDetailService
    {
        protected readonly IUnitOfWork _UnitOfWork;

        public PersonalDetailService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
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