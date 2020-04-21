using CVBuilder.Repository.Repositories.Interfaces;
using CVBuilder.Service.DTOs;
using CVBuilder.Service.Interfaces;

namespace CVBuilder.Service.Implementations
{
    public class TemplateService : UnitOfWork, ITemplateService
    {
        public TemplateService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
        }

        public void ChangeTemplate(string path, int curriculumId, int userId)
        {
            throw new System.NotImplementedException();
        }

        public TemplateDTO GetByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public string GetPreviewPath(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}