using CVBuilder.Core.DTOs;

namespace CVBuilder.Core.Services
{
    public interface ICurriculumService
    {
        int Create(int userId);
        int GetByUserId(int userId);
        FinishedDTO GetCurriculumContent(int userId, int curriculumId);
    }
}