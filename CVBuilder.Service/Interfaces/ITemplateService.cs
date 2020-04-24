using CVBuilder.Repository.DTOs;

namespace CVBuilder.Service.Interfaces
{
    public interface ITemplateService
    {
        TemplateDTO GetByUserId(int userId);
        string GetPreviewPath(int userId);
        void ChangeTemplate(string path, int curriculumId, int userId);
    }
}