using System.Collections.Generic;
using CVBuilder.Core;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Services;
using CVBuilder.Service.Helpers;

namespace CVBuilder.Service.Services
{
    public class StudyService : ISectionService<StudyDTO>
    {
        protected readonly IUnitOfWork _UnitOfWork;

        public StudyService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public int Create(StudyDTO dto)
        {
            return _UnitOfWork.Study.Create(dto);
        }

        public void Update(StudyDTO dto)
        {
            _UnitOfWork.Study.Update(dto, nameof(dto.StudyId));
        }

        public int Delete(int id)
        {
            return _UnitOfWork.Study.Delete(id);
        }

        public StudyDTO GetById(int id)
        {
            return _UnitOfWork.Study.GetById(id);
        }

        public IEnumerable<StudyDTO> GetAll(int curriculumId)
        {
            return _UnitOfWork.Study.GetAll(curriculumId);
        }

        public IEnumerable<StudyDTO> GetAllVisible(int curriculumId)
        {
            return _UnitOfWork.Study.GetAllVisible(curriculumId);
        }

        public List<SummaryBlockDTO> GetSummaryBlocks(int curriculumId)
        {
            IEnumerable<StudyDTO> allStudies = _UnitOfWork.Study.GetAll(curriculumId);
            List<SummaryBlockDTO> studyBlocks = new List<SummaryBlockDTO>();

            foreach(StudyDTO study in allStudies)
            {
                studyBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = study.StudyId,
                    Title = study.Title,
                    TimePeriod = GlobalVariables.GenerateTimePeriodFormat(study.StartMonth, study.StartYear, study.EndMonth, study.EndYear),
                    IsVisible = study.IsVisible
                });
            }

            return studyBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            StudyDTO study;

            if (id > 0)
                study = _UnitOfWork.Study.GetById(id);
            else
                study = _UnitOfWork.Study.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = study.StudyId,
                Title = study.Title,
                TimePeriod = GlobalVariables.GenerateTimePeriodFormat(study.StartMonth, study.StartYear, study.EndMonth, study.EndYear),
                IsVisible = study.IsVisible
            };
        }

        public void ToggleVisibility(int curriculumId)
        {
            _UnitOfWork.Study.ToggleVisibility("StudiesIsVisible", curriculumId);
        }
    }
}