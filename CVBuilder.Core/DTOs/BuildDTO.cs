using System.Collections.Generic;

namespace CVBuilder.Core.DTOs
{
    public class BuildDTO
    {
        public PersonalDetailDTO PersonalDetail { get; set; }
        public IEnumerable<SummaryBlockDTO> Studies { get; set; }
        public IEnumerable<SummaryBlockDTO> WorkExperiences { get; set; }
        public IEnumerable<SummaryBlockDTO> Certificates { get; set; }
        public IEnumerable<SummaryBlockDTO> Languages { get; set; }
        public IEnumerable<SummaryBlockDTO> Skills { get; set; }
        public IEnumerable<SummaryBlockDTO> Interests { get; set; }
        public IEnumerable<SummaryBlockDTO> PersonalReferences { get; set; }
        public IEnumerable<SummaryBlockDTO> CustomSections { get; set; }
        public string TemplatePath { get; set; }
        public SectionVisibilityDTO SectionVisibilities { get; set; }
    }
}