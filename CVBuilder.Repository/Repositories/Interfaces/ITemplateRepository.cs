using CVBuilder.Domain.Models;

namespace CVBuilder.Repository.Repositories.Interfaces
{
    public interface ITemplateRepository
    {
        Template GetByUserId(int userId);
        string GetPreviewPath(int userId);
        void ChangeTemplate(string path, int curriculumId, int userId);
    }
}