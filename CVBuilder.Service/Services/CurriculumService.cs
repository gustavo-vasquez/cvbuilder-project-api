using System;
using System.Collections.Generic;
using System.Reflection;
using CVBuilder.Core;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Helpers;
using CVBuilder.Core.Services;

namespace CVBuilder.Service.Services
{
    public class CurriculumService : ICurriculumService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IPersonalDetailService _personalDetailService;
        private readonly ISectionService<StudyDTO> _studyService;
        private readonly ISectionService<WorkExperienceDTO> _workExperience;
        private readonly ISectionService<CertificateDTO> _certificateService;
        private readonly ISectionService<LanguageDTO> _languageService;
        private readonly ISectionService<SkillDTO> _skillService;
        private readonly ISectionService<InterestDTO> _interestService;
        private readonly ISectionService<PersonalReferenceDTO> _personalReferenceService;
        private readonly ISectionService<CustomSectionDTO> _customSectionService;

        public CurriculumService(
            IUnitOfWork unitOfWork,
            IPersonalDetailService personalDetailService,
            ISectionService<StudyDTO> studyService,
            ISectionService<WorkExperienceDTO> workExperience,
            ISectionService<CertificateDTO> certificateService,
            ISectionService<LanguageDTO> languageService,
            ISectionService<SkillDTO> skillService,
            ISectionService<InterestDTO> interestService,
            ISectionService<PersonalReferenceDTO> personalReferenceService,
            ISectionService<CustomSectionDTO> customSectionService
        )
        {
            _UnitOfWork = unitOfWork;
            _personalDetailService = personalDetailService;
            _studyService = studyService;
            _workExperience = workExperience;
            _certificateService = certificateService;
            _languageService = languageService;
            _skillService = skillService;
            _interestService = interestService;
            _personalReferenceService = personalReferenceService;
            _customSectionService = customSectionService;
        }

        public int Create(int userId)
        {
            return _UnitOfWork.Curriculum.Create(userId);
        }

        public int GetByUserId(int userId)
        {
            return _UnitOfWork.Curriculum.GetIdByUserId(userId);
        }

        public BuildDTO GetContent(string email)
        {
            int userId = _UnitOfWork.User.GetUserIdByEmail(email);
            int curriculumId = _UnitOfWork.Curriculum.GetIdByUserId(userId);

            if(curriculumId > 0)
            {
                return new BuildDTO()
                {
                    PersonalDetail = _UnitOfWork.PersonalDetail.GetByCurriculumId(curriculumId),
                    Studies = _studyService.GetSummaryBlocks(curriculumId),
                    WorkExperiences = _workExperience.GetSummaryBlocks(curriculumId),
                    Certificates = _certificateService.GetSummaryBlocks(curriculumId),
                    PersonalReferences = _personalReferenceService.GetSummaryBlocks(curriculumId),
                    Languages = _languageService.GetSummaryBlocks(curriculumId),
                    Skills = _skillService.GetSummaryBlocks(curriculumId),
                    Interests = _interestService.GetSummaryBlocks(curriculumId),
                    CustomSections = _customSectionService.GetSummaryBlocks(curriculumId),
                    TemplatePath = _UnitOfWork.Template.GetPreviewPath(userId),
                    SectionVisibilities = _UnitOfWork.Curriculum.GetIsVisibleStates(curriculumId),
                    CurriculumId = curriculumId
                };
            }
            else
            {
                _UnitOfWork.Curriculum.Create(userId);
                return new BuildDTO()
                {
                    PersonalDetail = null,
                    Studies = null,
                    WorkExperiences = null,
                    Certificates = null,
                    PersonalReferences = null,
                    Languages = null,
                    Skills = null,
                    Interests = null,
                    CustomSections = null,
                    TemplatePath = _UnitOfWork.Template.GetPreviewPath(userId),
                    SectionVisibilities = _UnitOfWork.Curriculum.GetIsVisibleStates(curriculumId)
                };
            }
        }

        public dynamic GetSectionFormData(SectionNames section, int id)
        {
            switch(section)
            {
                case SectionNames.Study: return this._studyService.GetById(id);
                case SectionNames.WorkExperience: return this._workExperience.GetById(id);
                case SectionNames.Certificate: return this._certificateService.GetById(id);
                case SectionNames.Language: return this._languageService.GetById(id);
                case SectionNames.Skill: return this._skillService.GetById(id);
                case SectionNames.Interest: return this._interestService.GetById(id);
                case SectionNames.PersonalReference: return this._personalReferenceService.GetById(id);
                case SectionNames.CustomSection: return this._customSectionService.GetById(id);
                default: throw new ArgumentException("La sección proporcionada no existe.");
            }
        }

        public SummaryBlockDTO GetSectionBlock(SectionNames section, int id)
        {
            var sectionService = this.GetCurrentSectionService(section);
            object[] parameters = { id };
            var summaryBlock = sectionService.GetType().GetMethod("GetSummaryBlock").Invoke(sectionService, parameters);
            return (SummaryBlockDTO)summaryBlock;
        }

        public void AddOrUpdateSectionBlock<T>(T dto, FormMode mode, SectionNames section)
        {
            var sectionService = this.GetCurrentSectionService(section);
            object[] parameters = { dto };
            switch(mode)
            {
                case FormMode.ADD: sectionService.GetType().GetMethod("Create").Invoke(sectionService, parameters); break;
                case FormMode.EDIT: sectionService.GetType().GetMethod("Update").Invoke(sectionService, parameters); break;
                default: throw new ArgumentException("Ocurrió un problema al agregar/actualizar la sección.");
            }
        }

        public void DeleteSectionBlock(SectionNames section, int id)
        {
            var sectionService = this.GetCurrentSectionService(section);
            object[] parameters = { id };
            sectionService.GetType().GetMethod("Delete").Invoke(sectionService, parameters);
        }

        public void ToggleSectionVisibility(SectionNames section, string email)
        {
            var userId = _UnitOfWork.User.GetUserIdByEmail(email);
            var curriculumId = _UnitOfWork.Curriculum.GetIdByUserId(userId);
            var sectionService = this.GetCurrentSectionService(section);
            object[] parameters = { curriculumId };
            sectionService.GetType().GetMethod("ToggleVisibility").Invoke(sectionService, parameters);
        }

        public FinishedDTO GetContentReady(int userId, int curriculumId)
        {
            return new FinishedDTO()
            {
                PersonalDetails = _UnitOfWork.PersonalDetail.GetByCurriculumId(curriculumId),
                Studies = _UnitOfWork.Study.GetAllVisible(curriculumId),
                WorkExperiences = _UnitOfWork.WorkExperience.GetAllVisible(curriculumId),
                Certificates = _UnitOfWork.Certificate.GetAllVisible(curriculumId),
                PersonalReferences = _UnitOfWork.PersonalReference.GetAllVisible(curriculumId),
                Languages = _UnitOfWork.Language.GetAllVisible(curriculumId),
                Skills = _UnitOfWork.Skill.GetAllVisible(curriculumId),
                Interests = _UnitOfWork.Interest.GetAll(curriculumId),
                CustomSections = _UnitOfWork.CustomSection.GetAllVisible(curriculumId),
                Templates = _UnitOfWork.Template.GetByUserId(userId),
                SectionVisibility = _UnitOfWork.Curriculum.GetIsVisibleStates(curriculumId)
            };
        }

        #region - HELPER METHODS -

        private string GetPropertyName(SectionNames section)
        {
            switch(section)
            {
                case SectionNames.PersonalDetail: return nameof(_personalDetailService);
                case SectionNames.Study: return nameof(_studyService);
                case SectionNames.WorkExperience: return nameof(_workExperience);
                case SectionNames.Certificate: return nameof(_certificateService);
                case SectionNames.Language: return nameof(_languageService);
                case SectionNames.Skill: return nameof(_skillService);
                case SectionNames.Interest: return nameof(_interestService);
                case SectionNames.PersonalReference: return nameof(_personalReferenceService);
                case SectionNames.CustomSection: return nameof(_customSectionService);
                default: throw new ArgumentException("La sección indicada no es válida.");
            }
        }

        private object GetCurrentSectionService(SectionNames section)
        {
            return GetType().GetField(this.GetPropertyName(section), BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this);
        }

        #endregion
    }
}