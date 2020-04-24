using System.Collections.Generic;
using CVBuilder.Repository.DTOs;
using CVBuilder.Repository.Repositories.Interfaces;
using CVBuilder.Service.Interfaces;

namespace CVBuilder.Service.Implementations
{
    public class PersonalReferenceService : UnitOfWork, IService<PersonalReferenceDTO>
    {
        public PersonalReferenceService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
        }

        public int Create(PersonalReferenceDTO dto)
        {
            return _UnitOfWork.PersonalReference.Create(dto);
        }

        public void Update(PersonalReferenceDTO dto)
        {
            _UnitOfWork.PersonalReference.Update(dto, "PersonalReferenceId");
        }

        public int Delete(int id)
        {
            return _UnitOfWork.PersonalReference.Delete(id);
        }

        public PersonalReferenceDTO GetById(int id)
        {
            return _UnitOfWork.PersonalReference.GetById(id);
        }

        public IEnumerable<PersonalReferenceDTO> GetAll(int curriculumId)
        {
            return _UnitOfWork.PersonalReference.GetAll(curriculumId);
        }

        public IEnumerable<PersonalReferenceDTO> GetAllVisible(int curriculumId)
        {
            return _UnitOfWork.PersonalReference.GetAllVisible(curriculumId);
        }

        public List<SummaryBlockDTO> GetAllBlocks(int curriculumId)
        {
            IEnumerable<PersonalReferenceDTO> allPersonalReferences = _UnitOfWork.PersonalReference.GetAll(curriculumId);
            List<SummaryBlockDTO> personalReferenceBlocks = new List<SummaryBlockDTO>();

            foreach (PersonalReferenceDTO personalReference in allPersonalReferences)
            {
                personalReferenceBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = personalReference.PersonalReferenceId,
                    Title = personalReference.ContactPerson + " desde " + personalReference.Company,
                    IsVisible = personalReference.IsVisible
                });
            }

            return personalReferenceBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            PersonalReferenceDTO personalReference;

            if (id > 0)
                personalReference = _UnitOfWork.PersonalReference.GetById(id);
            else
                personalReference = _UnitOfWork.PersonalReference.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = personalReference.PersonalReferenceId,
                Title = personalReference.ContactPerson + " desde " + personalReference.Company,
                IsVisible = personalReference.IsVisible
            };
        }

        public void ToggleVisibility(int curriculumId)
        {
            _UnitOfWork.PersonalReference.ToggleVisibility("PersonalReferencesIsVisible", curriculumId);
        }
    }
}