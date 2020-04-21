using CVBuilder.Service.DTOs;

namespace CVBuilder.Service.Interfaces
{
    public interface IPersonalDetailService
    {
        int Create(PersonalDetailDTO dto, int curriculumId);
        int Update(PersonalDetailDTO dto, int curriculumId);
        PersonalDetailDTO GetByCurriculumId(int curriculumId);
    }
}