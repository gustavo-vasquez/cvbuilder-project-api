using System;
using System.Security.Claims;
using CVBuilder.Automapper;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Helpers;
using CVBuilder.Core.Services;
using CVBuilder.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CVBuilder.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumController : ControllerBase
    {
        private ICurriculumService _curriculumService;
        private ITemplateService _templateService;

        public CurriculumController(ICurriculumService curriculumService, ITemplateService templateService)
        {
            _curriculumService = curriculumService;
            _templateService = templateService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            BuildDTO dto = _curriculumService.GetContent(User.Identity.Name);
            return Ok(dto);
        }

        [HttpGet("block/{section}/{id}")]
        public IActionResult GetSectionBlock(SectionNames section, int id)
        {
            SummaryBlockDTO dto = _curriculumService.GetSectionBlock(section, id);
            return Ok(dto);
        }

        [HttpDelete("block/{section}/{id}")]
        public IActionResult DeleteBlock(SectionNames section, int id)
        {
            _curriculumService.DeleteSectionBlock(section, id);
            return Ok("Bloque de sección eliminado.");
        }

        [HttpPost("personalDetail")]
        public IActionResult ManagePersonalDetail([FromBody]PersonalDetailModel model)
        {
            PersonalDetailDTO dto = Mapping.Mapper.Map<PersonalDetailModel,PersonalDetailDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<PersonalDetailDTO>(dto, model.FormMode, SectionNames.PersonalDetail);

            return Ok("Cambios guardados.");
        }

        [HttpPut("personalDetail")]
        public IActionResult UpdatePersonalDetail([FromBody]PersonalDetailModel model)
        {
            PersonalDetailDTO dto = Mapping.Mapper.Map<PersonalDetailModel,PersonalDetailDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<PersonalDetailDTO>(dto, model.FormMode, SectionNames.PersonalDetail);

            return Ok("Cambios guardados.");
        }

        [HttpPost("study")]
        public IActionResult ManageStudy([FromBody]StudyModel model)
        {
            StudyDTO dto = Mapping.Mapper.Map<StudyModel,StudyDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<StudyDTO>(dto, model.FormMode, SectionNames.Study);

            return Ok(new { formid = "#" + model.FormId, id = model.StudyId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPost("workExperience")]
        public IActionResult ManageWorkExperience([FromBody]WorkExperienceModel model)
        {
            WorkExperienceDTO dto = Mapping.Mapper.Map<WorkExperienceModel,WorkExperienceDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<WorkExperienceDTO>(dto, model.FormMode, SectionNames.WorkExperience);

            return Ok(new { formid = "#" + model.FormId, id = model.WorkExperienceId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPost("certificate")]
        public IActionResult ManageCertificate([FromBody]CertificateModel model)
        {
            CertificateDTO dto = Mapping.Mapper.Map<CertificateModel,CertificateDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<CertificateDTO>(dto, model.FormMode, SectionNames.Certificate);

            return Ok(new { formid = "#" + model.FormId, id = model.CertificateId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPost("language")]
        public IActionResult ManageLanguage([FromBody]LanguageModel model)
        {
            LanguageDTO dto = Mapping.Mapper.Map<LanguageModel,LanguageDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<LanguageDTO>(dto, model.FormMode, SectionNames.Language);

            return Ok(new { formid = "#" + model.FormId, id = model.LanguageId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPost("skill")]
        public IActionResult ManageSkill([FromBody]SkillModel model)
        {
            SkillDTO dto = Mapping.Mapper.Map<SkillModel,SkillDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<SkillDTO>(dto, model.FormMode, SectionNames.Skill);

            return Ok(new { formid = "#" + model.FormId, id = model.SkillId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPost("interest")]
        public IActionResult ManageInterest([FromBody]InterestModel model)
        {
            InterestDTO dto = Mapping.Mapper.Map<InterestModel,InterestDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<InterestDTO>(dto, model.FormMode, SectionNames.Interest);

            return Ok(new { formid = "#" + model.FormId, id = model.InterestId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPost("personalReference")]
        public IActionResult ManagePersonalReference([FromBody]PersonalReferenceModel model)
        {
            PersonalReferenceDTO dto = Mapping.Mapper.Map<PersonalReferenceModel,PersonalReferenceDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<PersonalReferenceDTO>(dto, model.FormMode, SectionNames.PersonalReference);

            return Ok(new { formid = "#" + model.FormId, id = model.PersonalReferenceId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPost("customSection")]
        public IActionResult ManageCustomSection([FromBody]CustomSectionModel model)
        {
            CustomSectionDTO dto = Mapping.Mapper.Map<CustomSectionModel,CustomSectionDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<CustomSectionDTO>(dto, model.FormMode, SectionNames.CustomSection);

            return Ok(new { formid = "#" + model.FormId, id = model.CustomSectionId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpGet("finished")]
        public ActionResult Finished()
        {
            int userId = System.Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            FinishedDTO dto = _curriculumService.GetCurriculumContent(userId, _curriculumService.GetByUserId(userId));

            return Ok(dto);
        }

        [HttpPut("template/{path}")]
        public void ChangeTemplate(string path)
        {
            var userId = System.Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _templateService.ChangeTemplate(path, _curriculumService.GetByUserId(userId), userId);
        }

        [HttpPost("visibility/{section}")]
        public void ToggleSectionVisibility(SectionNames section)
        {
            _curriculumService.ToggleSectionVisibility(section, User.Identity.Name);
        }
    }
}