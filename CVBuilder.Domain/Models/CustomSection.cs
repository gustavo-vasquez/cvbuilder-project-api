using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVBuilder.Domain.Models
{
    public class CustomSection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomSectionId { get; set; }

        [Required]
        public string SectionName { get; set; }

        [Required]
        public string Description { get; set; }
        public bool IsVisible { get; set; }

        public int Id_Curriculum { get; set; }

        [ForeignKey("Id_Curriculum")]
        public Curriculum Curriculum { get; set; }
    }
}