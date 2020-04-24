using System.Collections.Generic;
using CVBuilder.Repository.DTOs;
using CVBuilder.Repository.Repositories.Interfaces;
using CVBuilder.Service.Helpers;
using CVBuilder.Service.Interfaces;

namespace CVBuilder.Service.Implementations
{
    public class SkillService : UnitOfWork, IService<SkillDTO>
    {
        public SkillService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
        }

        public int Create(SkillDTO dto)
        {
            return _UnitOfWork.Skill.Create(dto);
        }

        public void Update(SkillDTO dto)
        {
            _UnitOfWork.Skill.Update(dto, "SkillId");
        }

        public int Delete(int id)
        {
            return _UnitOfWork.Skill.Delete(id);
        }

        public SkillDTO GetById(int id)
        {
            return _UnitOfWork.Skill.GetById(id);
        }

        public IEnumerable<SkillDTO> GetAll(int curriculumId)
        {
            return _UnitOfWork.Skill.GetAll(curriculumId);
        }

        public IEnumerable<SkillDTO> GetAllVisible(int curriculumId)
        {
            return _UnitOfWork.Skill.GetAllVisible(curriculumId);
        }

        public List<SummaryBlockDTO> GetAllBlocks(int curriculumId)
        {
            IEnumerable<SkillDTO> allSkills = _UnitOfWork.Skill.GetAll(curriculumId);
            List<SummaryBlockDTO> skillBlocks = new List<SummaryBlockDTO>();

            foreach (SkillDTO skill in allSkills)
            {
                skillBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = skill.SkillId,
                    Title = skill.Name,
                    StateInTime = "(" + LevelOptions.LevelComboBox[skill.Level] + ")",
                    IsVisible = skill.IsVisible
                });
            }

            return skillBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            SkillDTO skill;

            if (id > 0)
                skill = _UnitOfWork.Skill.GetById(id);
            else
                skill = _UnitOfWork.Skill.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = skill.SkillId,
                Title = skill.Name,
                StateInTime = "(" + LevelOptions.LevelComboBox[skill.Level] + ")",
                IsVisible = skill.IsVisible
            };
        }

        public void ToggleVisibility(int curriculumId)
        {
            _UnitOfWork.Skill.ToggleVisibility("SkillsIsVisible", curriculumId);
        }
    }
}