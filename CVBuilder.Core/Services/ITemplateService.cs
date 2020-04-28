using CVBuilder.Core.DTOs;

namespace CVBuilder.Core.Services
{
    public interface ITemplateService
    {
        TemplateDTO GetByUserId(int userId);
        string GetPreviewPath(int userId);
        void ChangeTemplate(string path, int curriculumId, int userId);
    }
}