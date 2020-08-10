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
        public IActionResult GetCurriculum()
        {
            BuildDTO dto = _curriculumService.GetContent(User.Identity.Name);
            return Ok(dto);
        }

        [HttpGet("block/{sectionName}/{id}")]
        public IActionResult GetSectionBlock(SectionNames sectionName, int id)
        {
            SummaryBlockDTO dto = _curriculumService.GetSectionBlock(sectionName, id);
            return Ok(dto);
        }

        [HttpDelete("block/{sectionName}/{id}")]
        public IActionResult DeleteSectionBlock(SectionNames sectionName, int id)
        {
            _curriculumService.DeleteSectionBlock(sectionName, id);
            return Ok(new { message = "Bloque de sección eliminado." });
        }

        [HttpGet("section/{name}/{id}")]
        public IActionResult SectionFormData(SectionNames name, int id)
        {
            try
            {
                dynamic sectionFormData = _curriculumService.GetSectionFormData(name, id);
                return Ok(sectionFormData);
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("personalDetail")]
        public IActionResult UpdatePersonalDetail([FromForm]PersonalDetailModel model)
        {
            PersonalDetailDTO dto = Mapping.Mapper.Map<PersonalDetailModel,PersonalDetailDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<PersonalDetailDTO>(dto, model.FormMode, SectionNames.PersonalDetail);

            return Ok(new { message = "Detalles personales actualizados."});
        }

        [AcceptVerbs("POST","PUT")]
        [Route("study")]
        public IActionResult Study([FromBody]StudyModel model)
        {
            StudyDTO dto = Mapping.Mapper.Map<StudyModel,StudyDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<StudyDTO>(dto, model.FormMode, SectionNames.Study);

            return Ok(new { id = model.StudyId });
        }

        [AcceptVerbs("POST","PUT")]
        [Route("workExperience")]
        public IActionResult WorkExperience([FromBody]WorkExperienceModel model)
        {
            WorkExperienceDTO dto = Mapping.Mapper.Map<WorkExperienceModel,WorkExperienceDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<WorkExperienceDTO>(dto, model.FormMode, SectionNames.WorkExperience);

            return Ok(new { id = model.WorkExperienceId });
        }

        [AcceptVerbs("POST","PUT")]
        [Route("certificate")]
        public IActionResult Certificate([FromBody]CertificateModel model)
        {
            CertificateDTO dto = Mapping.Mapper.Map<CertificateModel,CertificateDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<CertificateDTO>(dto, model.FormMode, SectionNames.Certificate);

            return Ok(new { id = model.CertificateId });
        }

        [AcceptVerbs("POST","PUT")]
        [Route("language")]
        public IActionResult Language([FromBody]LanguageModel model)
        {
            LanguageDTO dto = Mapping.Mapper.Map<LanguageModel,LanguageDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<LanguageDTO>(dto, model.FormMode, SectionNames.Language);

            return Ok(new { id = model.LanguageId });
        }

        [AcceptVerbs("POST","PUT")]
        [Route("skill")]
        public IActionResult Skill([FromBody]SkillModel model)
        {
            SkillDTO dto = Mapping.Mapper.Map<SkillModel,SkillDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<SkillDTO>(dto, model.FormMode, SectionNames.Skill);

            return Ok(new { id = model.SkillId });
        }

        [AcceptVerbs("POST","PUT")]
        [Route("interest")]
        public IActionResult Interest([FromBody]InterestModel model)
        {
            InterestDTO dto = Mapping.Mapper.Map<InterestModel,InterestDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<InterestDTO>(dto, model.FormMode, SectionNames.Interest);

            return Ok(new { id = model.InterestId });
        }

        [AcceptVerbs("POST","PUT")]
        [Route("personalReference")]
        public IActionResult PersonalReference([FromBody]PersonalReferenceModel model)
        {
            PersonalReferenceDTO dto = Mapping.Mapper.Map<PersonalReferenceModel,PersonalReferenceDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<PersonalReferenceDTO>(dto, model.FormMode, SectionNames.PersonalReference);

            return Ok(new { id = model.PersonalReferenceId });
        }

        [AcceptVerbs("POST","PUT")]
        [Route("customSection")]
        public IActionResult CustomSection([FromBody]CustomSectionModel model)
        {
            CustomSectionDTO dto = Mapping.Mapper.Map<CustomSectionModel,CustomSectionDTO>(model);
            _curriculumService.AddOrUpdateSectionBlock<CustomSectionDTO>(dto, model.FormMode, SectionNames.CustomSection);

            return Ok(new { id = model.CustomSectionId });
        }

        [HttpGet("ready")]
        public ActionResult Finished()
        {
            int userId = System.Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            FinishedDTO dto = _curriculumService.GetContentReady(userId, _curriculumService.GetByUserId(userId));

            return Ok(dto);
        }

        [HttpPut("template")]
        public IActionResult ChangeTemplate([FromBody]string templatePathUrl)
        {
            var userId = System.Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            string templateName = _templateService.ChangeTemplate(templatePathUrl, _curriculumService.GetByUserId(userId));

            if(templateName != null)
                return Ok(new { Message = "La plantilla " + templateName + " se ha aplicado." });
            else
                return BadRequest(new { Message = "No se ha podido cambiar la plantilla. Causa: ruta de plantilla incorrecta." });
        }

        [HttpPut("visibility/{sectionName}")]
        public void ToggleSectionVisibility(SectionNames sectionName)
        {
            _curriculumService.ToggleSectionVisibility(sectionName, User.Identity.Name);
        }
    }
}