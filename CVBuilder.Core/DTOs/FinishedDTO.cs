﻿using System.Collections.Generic;

namespace CVBuilder.Core.DTOs
{
    public class FinishedDTO
    {
        public PersonalDetailDTO PersonalDetail { get; set; }
        public IEnumerable<StudyDTO> Studies { get; set; }
        public IEnumerable<WorkExperienceDTO> WorkExperiences { get; set; }
        public IEnumerable<CertificateDTO> Certificates { get; set; }
        public IEnumerable<LanguageDTO> Languages { get; set; }
        public IEnumerable<SkillDTO> Skills { get; set; }
        public IEnumerable<InterestDTO> Interests { get; set; }
        public IEnumerable<PersonalReferenceDTO> PersonalReferences { get; set; }
        public IEnumerable<CustomSectionDTO> CustomSections { get; set; }
        public TemplateDTO Template { get; set; }
        public SectionVisibilityDTO SectionVisibility { get; set; }
    }
}
