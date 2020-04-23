using CVBuilder.Domain.Models;
using CVBuilder.Repository.DTOs;

namespace CVBuilder.Repository.Repositories.Interfaces
{
    public interface ICurriculumRepository
    {
        int Create(int userId);
        int GetByUserId(int userId);
        CurriculumDTO GetById(int curriculumId);
    }
}