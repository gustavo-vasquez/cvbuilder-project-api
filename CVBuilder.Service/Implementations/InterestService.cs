using System.Collections.Generic;
using CVBuilder.Repository.Repositories.Interfaces;
using CVBuilder.Service.DTOs;
using CVBuilder.Service.Interfaces;

namespace CVBuilder.Service.Implementations
{
    public class InterestService : UnitOfWork, IService<InterestDTO>
    {
        public InterestService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
        }

        public int Create(InterestDTO data, int curriculumId)
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

        public InterestDTO GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(InterestDTO data, int curriculumId)
        {
            throw new System.NotImplementedException();
        }
    }
}