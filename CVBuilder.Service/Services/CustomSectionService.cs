using System.Collections.Generic;
using CVBuilder.Core;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Services;

namespace CVBuilder.Service.Services
{
    public class CustomSectionService : ISectionService<CustomSectionDTO>
    {
        protected readonly IUnitOfWork _UnitOfWork;

        public CustomSectionService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public int Create(CustomSectionDTO dto)
        {
            return _UnitOfWork.CustomSection.Create(dto);
        }

        public void Update(CustomSectionDTO dto)
        {
            _UnitOfWork.CustomSection.Update(dto, nameof(dto.CustomSectionId));
        }

        public int Delete(int id)
        {
            return _UnitOfWork.CustomSection.Delete(id);
        }

        public CustomSectionDTO GetById(int id)
        {
            return _UnitOfWork.CustomSection.GetById(id);
        }

        public IEnumerable<CustomSectionDTO> GetAll(int curriculumId)
        {
            return _UnitOfWork.CustomSection.GetAll(curriculumId);
        }

        public IEnumerable<CustomSectionDTO> GetAllVisible(int curriculumId)
        {
            return _UnitOfWork.CustomSection.GetAllVisible(curriculumId);
        }

        public List<SummaryBlockDTO> GetSummaryBlocks(int curriculumId)
        {
            IEnumerable<CustomSectionDTO> allCustomSections = _UnitOfWork.CustomSection.GetAll(curriculumId);
            List<SummaryBlockDTO> customSectionBlocks = new List<SummaryBlockDTO>();

            foreach (CustomSectionDTO customSection in allCustomSections)
            {
                customSectionBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = customSection.CustomSectionId,
                    Title = customSection.SectionName,
                    IsVisible = customSection.IsVisible
                });
            }

            return customSectionBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            CustomSectionDTO customSection;

            if (id > 0)
                customSection = _UnitOfWork.CustomSection.GetById(id);
            else
                customSection = _UnitOfWork.CustomSection.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = customSection.CustomSectionId,
                Title = customSection.SectionName,
                IsVisible = customSection.IsVisible
            };
        }

        public void ToggleVisibility(int curriculumId)
        {
            _UnitOfWork.CustomSection.ToggleVisibility("CustomSectionsIsVisible", curriculumId);
        }
    }
}