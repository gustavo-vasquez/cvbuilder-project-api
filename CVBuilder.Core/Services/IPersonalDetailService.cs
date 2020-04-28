using CVBuilder.Core.DTOs;

namespace CVBuilder.Core.Services
{
    public interface IPersonalDetailService
    {
        int Create(PersonalDetailDTO dto);
        int Update(PersonalDetailDTO dto);
        PersonalDetailDTO GetByCurriculumId(int curriculumId);
    }
}