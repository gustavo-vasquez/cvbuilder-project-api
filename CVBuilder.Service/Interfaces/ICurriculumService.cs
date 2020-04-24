using CVBuilder.Repository.DTOs;

namespace CVBuilder.Service.Interfaces
{
    public interface ICurriculumService
    {
        int Create(int userId);
        int GetByUserId(int userId);
        FinishedDTO GetCurriculumContent(int userId, int curriculumId);
    }
}