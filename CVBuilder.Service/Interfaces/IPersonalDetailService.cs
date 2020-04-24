using CVBuilder.Repository.DTOs;

namespace CVBuilder.Service.Interfaces
{
    public interface IPersonalDetailService
    {
        int Create(PersonalDetailDTO dto);
        int Update(PersonalDetailDTO dto);
        PersonalDetailDTO GetByCurriculumId(int curriculumId);
    }
}