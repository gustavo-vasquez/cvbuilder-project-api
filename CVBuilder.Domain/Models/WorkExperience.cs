using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVBuilder.Domain.Models
{
    public class WorkExperience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkExperienceId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Job { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Company { get; set; }

        [Required]
        [MaxLength(50)]
        public string StartMonth { get; set; }
        public int StartYear { get; set; }

        [Required]
        [MaxLength(50)]
        public string EndMonth { get; set; }
        public int EndYear { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }
        public bool IsVisible { get; set; }

        public int Id_Curriculum { get; set; }

        [ForeignKey("Id_Curriculum")]
        public Curriculum Curriculum { get; set; }
    }
}