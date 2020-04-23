using CVBuilder.Repository.DTOs;

namespace CVBuilder.Repository.Repositories.Interfaces
{
    public interface ITemplateRepository
    {
        TemplateDTO GetByUserId(int userId);
        string GetPreviewPath(int userId);
        void ChangeTemplate(string path, int curriculumId, int userId);
    }
}