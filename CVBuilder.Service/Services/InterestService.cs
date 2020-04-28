using System.Collections.Generic;
using CVBuilder.Core;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Services;

namespace CVBuilder.Service.Services
{
    public class InterestService : ISectionService<InterestDTO>
    {
        protected readonly IUnitOfWork _UnitOfWork;

        public InterestService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public int Create(InterestDTO dto)
        {
            return _UnitOfWork.Interest.Create(dto);
        }

        public void Update(InterestDTO dto)
        {
            _UnitOfWork.Interest.Update(dto, nameof(dto.InterestId));
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