using System.Collections.Generic;
using CVBuilder.Repository.DTOs;
using CVBuilder.Repository.Repositories.Interfaces;
using CVBuilder.Service.Helpers;
using CVBuilder.Service.Interfaces;

namespace CVBuilder.Service.Implementations
{
    public class LanguageService : UnitOfWork, IService<LanguageDTO>
    {
        public LanguageService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
        }

        public int Create(LanguageDTO dto)
        {
            return _UnitOfWork.Language.Create(dto);
        }

        public void Update(LanguageDTO dto)
        {
            _UnitOfWork.Language.Update(dto, "LanguageId");
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

        public List<SummaryBlockDTO> GetAllBlocks(int curriculumId)
        {
            IEnumerable<LanguageDTO> allLanguages = _UnitOfWork.Language.GetAll(curriculumId);
            List<SummaryBlockDTO> languageBlocks = new List<SummaryBlockDTO>();

            foreach (LanguageDTO language in allLanguages)
            {
                languageBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = language.LanguageId,
                    Title = language.Name,
                    StateInTime = "(" + LevelOptions.LevelComboBox[language.Level] + ")",
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
                StateInTime = "(" + LevelOptions.LevelComboBox[language.Level] + ")",
                IsVisible = language.IsVisible
            };
        }

        public void ToggleVisibility(int curriculumId)
        {
            _UnitOfWork.Language.ToggleVisibility("LanguagesIsVisible", curriculumId);
        }
    }
}