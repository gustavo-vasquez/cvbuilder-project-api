namespace CVBuilder.Repository.DTOs
{
    public class CurriculumDTO
    {
        public int CurriculumId { get; set; }
        public bool StudiesIsVisible { get; set; }
        public bool WorkExperiencesIsVisible { get; set; }
        public bool CertificatesIsVisible { get; set; }
        public bool LanguagesIsVisible { get; set; }
        public bool SkillsIsVisible { get; set; }
        public bool InterestsIsVisible { get; set; }
        public bool PersonalReferencesIsVisible { get; set; }
        public bool CustomSectionsIsVisible { get; set; }
    }
}