using System.Collections.Generic;
using CVBuilder.Core;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Services;
using CVBuilder.Service.Helpers;

namespace CVBuilder.Service.Services
{
    public class WorkExperienceService : ISectionService<WorkExperienceDTO>
    {
        protected readonly IUnitOfWork _UnitOfWork;
        
        public WorkExperienceService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public int Create(WorkExperienceDTO dto)
        {
            return _UnitOfWork.WorkExperience.Create(dto);
        }

        public void Update(WorkExperienceDTO dto)
        {
            _UnitOfWork.WorkExperience.Update(dto, nameof(dto.WorkExperienceId));
        }

        public int Delete(int id)
        {
            return _UnitOfWork.WorkExperience.Delete(id);
        }

        public WorkExperienceDTO GetById(int id)
        {
            return _UnitOfWork.WorkExperience.GetById(id);
        }

        public IEnumerable<WorkExperienceDTO> GetAll(int curriculumId)
        {
            return _UnitOfWork.WorkExperience.GetAll(curriculumId);
        }

        public IEnumerable<WorkExperienceDTO> GetAllVisible(int curriculumId)
        {
            return _UnitOfWork.WorkExperience.GetAllVisible(curriculumId);
        }

        public List<SummaryBlockDTO> GetSummaryBlocks(int curriculumId)
        {
            IEnumerable<WorkExperienceDTO> allWorkExperiences = _UnitOfWork.WorkExperience.GetAll(curriculumId);
            List<SummaryBlockDTO> workExperienceBlocks = new List<SummaryBlockDTO>();

            foreach (WorkExperienceDTO workExperience in allWorkExperiences)
            {
                workExperienceBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = workExperience.WorkExperienceId,
                    Title = workExperience.Job + " en " + workExperience.Company,
                    TimePeriod = GlobalVariables.GenerateTimePeriodFormat(workExperience.StartMonth, workExperience.StartYear, workExperience.EndMonth, workExperience.EndYear),
                    IsVisible = workExperience.IsVisible
                });
            }

            return workExperienceBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            WorkExperienceDTO workExperience;

            if (id > 0)
                workExperience = _UnitOfWork.WorkExperience.GetById(id);
            else
                workExperience = _UnitOfWork.WorkExperience.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = workExperience.WorkExperienceId,
                Title = workExperience.Job + " en " + workExperience.Company,
                TimePeriod = GlobalVariables.GenerateTimePeriodFormat(workExperience.StartMonth, workExperience.StartYear, workExperience.EndMonth, workExperience.EndYear),
                IsVisible = workExperience.IsVisible
            };
        }

        public void ToggleVisibility(int curriculumId)
        {
            _UnitOfWork.WorkExperience.ToggleVisibility("WorkExperiencesIsVisible", curriculumId);
        }
    }
}