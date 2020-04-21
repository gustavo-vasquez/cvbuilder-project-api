using System.Collections.Generic;
using CVBuilder.Repository.Repositories.Interfaces;
using CVBuilder.Service.DTOs;
using CVBuilder.Service.Interfaces;

namespace CVBuilder.Service.Implementations
{
    public class CertificateService : UnitOfWork, IService<CertificateDTO>
    {
        public CertificateService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
        }

        public int Create(CertificateDTO data, int curriculumId)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<SummaryBlockDTO> GetAllBlocks(int curriculumId)
        {
            throw new System.NotImplementedException();
        }

        public CertificateDTO GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(CertificateDTO data, int curriculumId)
        {
            throw new System.NotImplementedException();
        }
    }
}