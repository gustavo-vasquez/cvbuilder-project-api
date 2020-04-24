using System.Collections.Generic;
using CVBuilder.Repository.DTOs;
using CVBuilder.Repository.Repositories.Interfaces;
using CVBuilder.Service.Interfaces;

namespace CVBuilder.Service.Implementations
{
    public class InterestService : UnitOfWork, IService<InterestDTO>
    {
        public InterestService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
        }

        public int Create(InterestDTO dto)
        {
            return _UnitOfWork.Interest.Create(dto);
        }

        public void Update(InterestDTO dto)
        {
            _UnitOfWork.Interest.Update(dto, "InterestId");
        }

        public int Delete(int id)
        {
            return _UnitOfWork.Interest.Delete(id);
        }

        public InterestDTO GetById(int id)
        {
            return _UnitOfWork.Interest.GetById(id);
        }

        public IEnumerable<InterestDTO> GetAll(int curriculumId)
        {
            return _UnitOfWork.Interest.GetAll(curriculumId);
        }

        public IEnumerable<InterestDTO> GetAllVisible(int curriculumId)
        {
            return _UnitOfWork.Interest.GetAllVisible(curriculumId);
        }

        public List<SummaryBlockDTO> GetAllBlocks(int curriculumId)
        {
            IEnumerable<InterestDTO> allInterests = _UnitOfWork.Interest.GetAll(curriculumId);
            List<SummaryBlockDTO> interestBlocks = new List<SummaryBlockDTO>();

            foreach (InterestDTO interest in allInterests)
            {
                interestBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = interest.InterestId,
                    Title = interest.Name,
                    IsVisible = interest.IsVisible
                });
            }

            return interestBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            InterestDTO interest;

            if (id > 0)
                interest = _UnitOfWork.Interest.GetById(id);
            else
                interest = _UnitOfWork.Interest.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = interest.InterestId,
                Title = interest.Name,
                IsVisible = interest.IsVisible
            };
        }

        public void ToggleVisibility(int curriculumId)
        {
            _UnitOfWork.Interest.ToggleVisibility("InterestsIsVisible", curriculumId);
        }
    }
}