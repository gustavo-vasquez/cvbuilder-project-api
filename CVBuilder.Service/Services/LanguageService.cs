using System.Collections.Generic;
using CVBuilder.Core;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Services;
using CVBuilder.Service.Helpers;

namespace CVBuilder.Service.Services
{
    public class LanguageService : ISectionService<LanguageDTO>
    {
        protected readonly IUnitOfWork _UnitOfWork;

        public LanguageService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public int Create(LanguageDTO dto)
        {
            return _UnitOfWork.Language.Create(dto);
        }

        public void Update(LanguageDTO dto)
        {
            _UnitOfWork.Language.Update(dto, nameof(dto.LanguageId));
        }

        public int Delete(int id)
        {
            return _UnitOfWork.Language.Delete(id);
        }

        public LanguageDTO GetById(int id)
        {
            return _UnitOfWork.Language.GetById(id);
        }

        public IEnumerable<LanguageDTO> GetAll(int curriculumId)
        {
            return _UnitOfWork.Language.GetAll(curriculumId);
        }

        public IEnumerable<LanguageDTO> GetAllVisible(int curriculumId)
        {
            return _UnitOfWork.Language.GetAllVisible(curriculumId);
        }

        public List<SummaryBlockDTO> GetSummaryBlocks(int curriculumId)
        {
            IEnumerable<LanguageDTO> allLanguages = _UnitOfWork.Language.GetAll(curriculumId);
            List<SummaryBlockDTO> languageBlocks = new List<SummaryBlockDTO>();

            foreach (LanguageDTO language in allLanguages)
            {
                languageBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = language.LanguageId,
                    Title = language.Name,
                    TimePeriod = "(" + LevelOptions.LevelComboBox[language.Level] + ")",
                    IsVisible = language.IsVisible
                });
            }

            return languageBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            LanguageDTO language;

            if (id > 0)
                language = _UnitOfWork.Language.GetById(id);
            else
                language = _UnitOfWork.Language.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = language.LanguageId,
                Title = language.Name,
                TimePeriod = "(" + LevelOptions.LevelComboBox[language.Level] + ")",
                IsVisible = language.IsVisible
            };
        }

        public void ToggleVisibility(int curriculumId)
        {
            _UnitOfWork.Language.ToggleVisibility("LanguagesIsVisible", curriculumId);
        }
    }
}