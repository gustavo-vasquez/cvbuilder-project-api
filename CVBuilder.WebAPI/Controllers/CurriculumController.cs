using System;
using System.Security.Claims;
using System.Text.Json;
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

        [HttpGet("section/{name}/{id}")]
        public IActionResult GetSectionBlock(SectionNames name, int id)
        {
            SummaryBlockDTO dto = _curriculumService.GetSectionBlock(name, id);
            return Ok(dto);
        }

        [HttpDelete("section/{name}/{id}")]
        public IActionResult DeleteSectionBlock(SectionNames name, int id)
        {
            _curriculumService.DeleteSectionBlock(name, id);
            return Ok("Bloque de sección eliminado.");
        }

        /* [HttpPost("section/{name}")]
        public IActionResult NewSectionBlock([FromBody]JsonElement model, SectionNames name)
        {
            var studyJson = System.Text.Json.JsonSerializer.Serialize(model);
            var study = System.Text.Json.JsonSerializer.Deserialize<StudyModel>(studyJson);
            //var studymodel = model.;
            //StudyDTO dto = Mapping.Mapper.Map<SectionModel,StudyDTO>(studymodel);
            //_curriculumService.AddOrUpdateSectionBlock<StudyDTO>(dto, studymodel.FormMode, name);
            //return Ok(new { formid = "#" + model.FormId, id = model.StudyId, mode = Convert.ToInt32(model.FormMode) });
            return Ok("Nuevo bloque de sección añadido.");
        } */

        [HttpPost("personalDetail")]
        public IActionResult NewPersonalDetail([FromBody]PersonalDetailModel model)
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
        public IActionResult NewStudy([FromBody]StudyModel model)
        {
            StudyDTO dto = Mapping.Mapper.Map<StudyModel,StudyDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<StudyDTO>(dto, model.FormMode, SectionNames.Study);

            return Ok(new { formid = "#" + model.FormId, id = model.StudyId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPut("study")]
        public IActionResult UpdateStudy([FromBody]StudyModel model)
        {
            StudyDTO dto = Mapping.Mapper.Map<StudyModel,StudyDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<StudyDTO>(dto, model.FormMode, SectionNames.Study);

            return Ok(new { formid = "#" + model.FormId, id = model.StudyId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPost("workExperience")]
        public IActionResult NewWorkExperience([FromBody]WorkExperienceModel model)
        {
            WorkExperienceDTO dto = Mapping.Mapper.Map<WorkExperienceModel,WorkExperienceDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<WorkExperienceDTO>(dto, model.FormMode, SectionNames.WorkExperience);

            return Ok(new { formid = "#" + model.FormId, id = model.WorkExperienceId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPut("workExperience")]
        public IActionResult UpdateWorkExperience([FromBody]WorkExperienceModel model)
        {
            WorkExperienceDTO dto = Mapping.Mapper.Map<WorkExperienceModel,WorkExperienceDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<WorkExperienceDTO>(dto, model.FormMode, SectionNames.WorkExperience);

            return Ok(new { formid = "#" + model.FormId, id = model.WorkExperienceId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPost("certificate")]
        public IActionResult NewCertificate([FromBody]CertificateModel model)
        {
            CertificateDTO dto = Mapping.Mapper.Map<CertificateModel,CertificateDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<CertificateDTO>(dto, model.FormMode, SectionNames.Certificate);

            return Ok(new { formid = "#" + model.FormId, id = model.CertificateId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPut("certificate")]
        public IActionResult UpdateCertificate([FromBody]CertificateModel model)
        {
            CertificateDTO dto = Mapping.Mapper.Map<CertificateModel,CertificateDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<CertificateDTO>(dto, model.FormMode, SectionNames.Certificate);

            return Ok(new { formid = "#" + model.FormId, id = model.CertificateId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPost("language")]
        public IActionResult NewLanguage([FromBody]LanguageModel model)
        {
            LanguageDTO dto = Mapping.Mapper.Map<LanguageModel,LanguageDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<LanguageDTO>(dto, model.FormMode, SectionNames.Language);

            return Ok(new { formid = "#" + model.FormId, id = model.LanguageId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPut("language")]
        public IActionResult UpdateLanguage([FromBody]LanguageModel model)
        {
            LanguageDTO dto = Mapping.Mapper.Map<LanguageModel,LanguageDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<LanguageDTO>(dto, model.FormMode, SectionNames.Language);

            return Ok(new { formid = "#" + model.FormId, id = model.LanguageId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPost("skill")]
        public IActionResult NewSkill([FromBody]SkillModel model)
        {
            SkillDTO dto = Mapping.Mapper.Map<SkillModel,SkillDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<SkillDTO>(dto, model.FormMode, SectionNames.Skill);

            return Ok(new { formid = "#" + model.FormId, id = model.SkillId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPut("skill")]
        public IActionResult UpdateSkill([FromBody]SkillModel model)
        {
            SkillDTO dto = Mapping.Mapper.Map<SkillModel,SkillDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<SkillDTO>(dto, model.FormMode, SectionNames.Skill);

            return Ok(new { formid = "#" + model.FormId, id = model.SkillId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPost("interest")]
        public IActionResult NewInterest([FromBody]InterestModel model)
        {
            InterestDTO dto = Mapping.Mapper.Map<InterestModel,InterestDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<InterestDTO>(dto, model.FormMode, SectionNames.Interest);

            return Ok(new { formid = "#" + model.FormId, id = model.InterestId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPut("interest")]
        public IActionResult UpdateInterest([FromBody]InterestModel model)
        {
            InterestDTO dto = Mapping.Mapper.Map<InterestModel,InterestDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<InterestDTO>(dto, model.FormMode, SectionNames.Interest);

            return Ok(new { formid = "#" + model.FormId, id = model.InterestId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPost("personalReference")]
        public IActionResult NewPersonalReference([FromBody]PersonalReferenceModel model)
        {
            PersonalReferenceDTO dto = Mapping.Mapper.Map<PersonalReferenceModel,PersonalReferenceDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<PersonalReferenceDTO>(dto, model.FormMode, SectionNames.PersonalReference);

            return Ok(new { formid = "#" + model.FormId, id = model.PersonalReferenceId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPut("personalReference")]
        public IActionResult UpdatePersonalReference([FromBody]PersonalReferenceModel model)
        {
            PersonalReferenceDTO dto = Mapping.Mapper.Map<PersonalReferenceModel,PersonalReferenceDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<PersonalReferenceDTO>(dto, model.FormMode, SectionNames.PersonalReference);

            return Ok(new { formid = "#" + model.FormId, id = model.PersonalReferenceId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPost("customSection")]
        public IActionResult NewCustomSection([FromBody]CustomSectionModel model)
        {
            CustomSectionDTO dto = Mapping.Mapper.Map<CustomSectionModel,CustomSectionDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<CustomSectionDTO>(dto, model.FormMode, SectionNames.CustomSection);

            return Ok(new { formid = "#" + model.FormId, id = model.CustomSectionId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpPut("customSection")]
        public IActionResult UpdateCustomSection([FromBody]CustomSectionModel model)
        {
            CustomSectionDTO dto = Mapping.Mapper.Map<CustomSectionModel,CustomSectionDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<CustomSectionDTO>(dto, model.FormMode, SectionNames.CustomSection);

            return Ok(new { formid = "#" + model.FormId, id = model.CustomSectionId, mode = Convert.ToInt32(model.FormMode) });
        }

        [HttpGet("ready")]
        public ActionResult Finished()
        {
            int userId = System.Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            FinishedDTO dto = _curriculumService.GetContentReady(userId, _curriculumService.GetByUserId(userId));

            return Ok(dto);
        }

        [HttpPut("template")]
        public IActionResult ChangeTemplate([FromBody]string path)
        {
            var userId = System.Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            string templateName = _templateService.ChangeTemplate(path, _curriculumService.GetByUserId(userId));

            if(templateName != null)
                return Ok("La plantilla " + templateName + " se ha aplicado.");
            else
                return BadRequest("No se ha podido cambiar la plantilla. Causa: pathUrl incorrecto.");
        }

        [HttpPost("visibility/{name}")]
        public void ToggleSectionVisibility(SectionNames name)
        {
            _curriculumService.ToggleSectionVisibility(name, User.Identity.Name);
        }
    }
}