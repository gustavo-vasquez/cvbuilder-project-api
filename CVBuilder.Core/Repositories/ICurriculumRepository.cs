using CVBuilder.Core.DTOs;

namespace CVBuilder.Core.Repositories
{
    public interface ICurriculumRepository
    {
        int Create(int userId);
        int GetIdByUserId(int userId);
        CurriculumDTO GetById(int curriculumId);
        SectionVisibilityDTO GetIsVisibleStates(int curriculumId);
    }
}