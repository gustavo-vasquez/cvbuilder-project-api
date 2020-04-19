using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVBuilder.Domain.Models
{
    public class PersonalReference
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonalReferenceId { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string ContactPerson { get; set; }
        public short? AreaCode { get; set; }
        public int? Telephone { get; set; }

        [Required]
        public string Email { get; set; }
        public bool IsVisible { get; set; }

        public int Id_Curriculum { get; set; }

        [ForeignKey("Id_Curriculum")]
        public Curriculum Curriculum { get; set; }
    }
}