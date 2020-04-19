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
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        public string Profession { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoMimeType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int? PostalCode { get; set; }
        public int? LinePhone { get; set; }
        public short? AreaCodeLP { get; set; }
        public int? MobilePhone { get; set; }
        public short? AreaCodeMP { get; set; }

        [Required]
        public string Summary { get; set; }
        public string SummaryCustomTitle { get; set; }
        public bool SummaryIsVisible { get; set; }
        public string WebPageUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string GithubUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }

        public int Id_Curriculum { get; set; }

        [ForeignKey("Id_Curriculum")]
        public Curriculum Curriculum { get; set; }
    }
}