using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVBuilder.Domain.Models
{
    public class Study
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudyId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Institute { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string StartMonth { get; set; }
        public int StartYear { get; set; }

        [Required]
        public string EndMonth { get; set; }
        public int EndYear { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }

        public int Id_Curriculum { get; set; }

        [ForeignKey("Id_Curriculum")]
        public Curriculum Curriculum { get; set; }
    }
}