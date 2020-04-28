using CVBuilder.Core.DTOs;

namespace CVBuilder.Core.Repositories
{
    public interface IPersonalDetailRepository
    {
        int Create(PersonalDetailDTO data);
        int Update(PersonalDetailDTO data);
        PersonalDetailDTO GetByCurriculumId(int curriculumId);
    }
}