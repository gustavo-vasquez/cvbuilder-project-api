using CVBuilder.Repository.DTOs;
using CVBuilder.Repository.Repositories.Interfaces;
using CVBuilder.Service.Interfaces;

namespace CVBuilder.Service.Implementations
{
    public class TemplateService : UnitOfWork, ITemplateService
    {
        public TemplateService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
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