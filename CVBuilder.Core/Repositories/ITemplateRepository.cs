using CVBuilder.Core.DTOs;

namespace CVBuilder.Core.Repositories
{
    public interface ITemplateRepository
    {
        TemplateDTO GetByUserId(int userId);
        string GetPreviewPath(int userId);
        void ChangeTemplate(string path, int curriculumId, int userId);
    }
}