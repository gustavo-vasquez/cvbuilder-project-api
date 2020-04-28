using CVBuilder.Core;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Services;

namespace CVBuilder.Service.Services
{
    public class TemplateService : ITemplateService
    {
        protected readonly IUnitOfWork _UnitOfWork;

        public TemplateService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public TemplateDTO GetByUserId(int userId)
        {
            return _UnitOfWork.Template.GetByUserId(userId);
        }

        public string GetPreviewPath(int userId)
        {
            return _UnitOfWork.Template.GetPreviewPath(userId);
        }

        public void ChangeTemplate(string path, int curriculumId, int userId)
        {
            _UnitOfWork.Template.ChangeTemplate(path, curriculumId, userId);
        }
    }
}