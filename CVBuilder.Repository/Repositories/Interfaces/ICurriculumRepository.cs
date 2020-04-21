using CVBuilder.Domain.Models;

namespace CVBuilder.Repository.Repositories.Interfaces
{
    public interface ICurriculumRepository
    {
        int Create(int userId);
        int GetByUserId(int userId);
        Curriculum GetById(int curriculumId);
    }
}