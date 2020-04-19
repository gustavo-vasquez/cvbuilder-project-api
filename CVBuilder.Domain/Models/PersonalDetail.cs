using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVBuilder.Domain.Models
{
    public class PersonalDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonalDetailId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Profession { get; set; }
        public byte[] Photo { get; set; }

        [MaxLength(25)]
        public string PhotoMimeType { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string City { get; set; }
        public int? PostalCode { get; set; }
        public int? LinePhone { get; set; }
        public short? AreaCodeLP { get; set; }
        public int? MobilePhone { get; set; }
        public short? AreaCodeMP { get; set; }

        [Required]
        [MaxLength(300)]
        public string Summary { get; set; }

        [MaxLength(50)]
        public string SummaryCustomTitle { get; set; }
        public bool SummaryIsVisible { get; set; }

        [MaxLength(300)]
        public string WebPageUrl { get; set; }

        [MaxLength(300)]
        public string LinkedInUrl { get; set; }

        [MaxLength(300)]
        public string GithubUrl { get; set; }

        [MaxLength(300)]
        public string FacebookUrl { get; set; }

        [MaxLength(300)]
        public string TwitterUrl { get; set; }

        public int Id_Curriculum { get; set; }

        [ForeignKey("Id_Curriculum")]
        public Curriculum Curriculum { get; set; }
    }
}