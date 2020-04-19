using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVBuilder.Domain.Models
{
    public class Interest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterestId { get; set; }

        [Required]
        public string Name { get; set; }
        public bool IsVisible { get; set; }

        public int Id_Curriculum { get; set; }

        [ForeignKey("Id_Curriculum")]
        public Curriculum Curriculum { get; set; }
    }
}