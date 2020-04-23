using CVBuilder.Repository.DTOs;

namespace CVBuilder.Repository.Repositories.Interfaces
{
    public interface IPersonalDetailRepository
    {
        int Create(PersonalDetailDTO data);
        int Update(PersonalDetailDTO data);
        PersonalDetailDTO GetByCurriculumId(int curriculumId);
    }
}