using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVBuilder.Domain.Models
{
    public class Certificate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CertificateId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Institute { get; set; }
        public bool OnlineMode { get; set; }
        public bool InProgress { get; set; }
        public int? Year { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }
        public bool IsVisible { get; set; }

        public int Id_Curriculum { get; set; }

        [ForeignKey("Id_Curriculum")]
        public Curriculum Curriculum { get; set; }
    }
}