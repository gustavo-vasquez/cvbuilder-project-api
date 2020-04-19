using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVBuilder.Domain.Models
{
    public class Curriculum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurriculumId { get; set; }
        public bool StudiesIsVisible { get; set; }
        public bool WorkExperiencesIsVisible { get; set; }
        public bool CertificatesIsVisible { get; set; }
        public bool LanguagesIsVisible { get; set; }
        public bool SkillsIsVisible { get; set; }
        public bool InterestsIsVisible { get; set; }
        public bool PersonalReferencesIsVisible { get; set; }
        public bool CustomSectionsIsVisible { get; set; }

        public int Id_User { get; set; }

        [ForeignKey("Id_User")]
        public User User { get; set; }
        public int Id_Template { get; set; }

        [ForeignKey("Id_Template")]
        public Template Template { get; set; }

        public ICollection<PersonalDetail> PersonalDetails { get; set; }
        public ICollection<Study> Studies { get; set; }
        public ICollection<WorkExperience> WorkExperiences { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<Language> Languages { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Interest> Interests { get; set; }
        public ICollection<PersonalReference> PersonalReferences { get; set; }
        public ICollection<CustomSection> CustomSections { get; set; }
    }
}