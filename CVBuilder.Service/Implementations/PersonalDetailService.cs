using CVBuilder.Repository.Repositories.Interfaces;
using CVBuilder.Service.DTOs;
using CVBuilder.Service.Interfaces;

namespace CVBuilder.Service.Implementations
{
    public class PersonalDetailService : UnitOfWork, IPersonalDetailService
    {
        public PersonalDetailService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
        }

        public int Create(PersonalDetailDTO dto, int curriculumId)
        {
            /* PersonalDetail data = Mapping.Mapper.Map<PersonalDetailDTO, PersonalDetail>(dto);

            return _UnitOfWork.PersonalDetail.Create(data, curriculumId); */
            throw new System.NotImplementedException();
        }

        public int Update(PersonalDetailDTO dto, int curriculumId)
        {
            /* PersonalDetail data = Mapping.Mapper.Map<PersonalDetailDTO, PersonalDetail>(dto);

            return _UnitOfWork.PersonalDetail.Update(data, curriculumId); */
            throw new System.NotImplementedException();
        }

        public PersonalDetailDTO GetByCurriculumId(int curriculumId)
        {
            /* PersonalDetail data = _UnitOfWork.PersonalDetail.GetByCurriculumId(curriculumId);
            
            if (data != null)
                return Mapping.Mapper.Map<PersonalDetail, PersonalDetailDTO>(data);

            return null; */
            throw new System.NotImplementedException();
        }
    }
}