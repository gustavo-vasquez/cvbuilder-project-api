using System.Collections.Generic;

namespace CVBuilder.WebAPI.Models
{
    public class BuildModel
    {
        public PersonalDetailModel PersonalDetails { get; set; }
        public List<SummaryBlockModel> StudyBlocks { get; set; }
        public List<SummaryBlockModel> CertificateBlocks { get; set; }
        public List<SummaryBlockModel> WorkExperienceBlocks { get; set; }
        public List<SummaryBlockModel> LanguageBlocks { get; set; }
        public List<SummaryBlockModel> SkillBlocks { get; set; }
        public List<SummaryBlockModel> InterestBlocks { get; set; }
        public List<SummaryBlockModel> PersonalReferenceBlocks { get; set; }
        public List<SummaryBlockModel> CustomSectionBlocks { get; set; }
        public string PreviewPath { get; set; }
        public SectionVisibilityModel SectionVisibility { get; set; }

        public BuildModel()
        {
            PersonalDetails = new PersonalDetailModel();
            StudyBlocks = new List<SummaryBlockModel>();
            CertificateBlocks = new List<SummaryBlockModel>();
            WorkExperienceBlocks = new List<SummaryBlockModel>();
            LanguageBlocks = new List<SummaryBlockModel>();
            SkillBlocks = new List<SummaryBlockModel>();
            InterestBlocks = new List<SummaryBlockModel>();
            PersonalReferenceBlocks = new List<SummaryBlockModel>();
            CustomSectionBlocks = new List<SummaryBlockModel>();
            SectionVisibility = new SectionVisibilityModel();
        }
    }
}