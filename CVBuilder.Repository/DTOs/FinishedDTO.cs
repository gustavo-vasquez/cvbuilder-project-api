using System.Collections.Generic;

namespace CVBuilder.Repository.DTOs
{
    public class FinishedDTO
    {
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public string PreviewPath { get; set; }
        public PersonalDetailDTO PersonalDetails { get; set; }
        public List<StudyDTO> Studies { get; set; }
        public List<WorkExperienceDTO> WorkExperiences { get; set; }
        public List<CertificateDTO> Certificates { get; set; }
        public List<LanguageDTO> Languages { get; set; }
        public List<SkillDTO> Skills { get; set; }
        public List<InterestDTO> Interests { get; set; }
        public List<PersonalReferenceDTO> PersonalReferences { get; set; }
        public List<CustomSectionDTO> CustomSections { get; set; }
        public SectionVisibilityDTO SectionVisibility { get; set; }
    }
}
