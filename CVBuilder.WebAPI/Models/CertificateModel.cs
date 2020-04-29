using System.ComponentModel.DataAnnotations;
using CVBuilder.WebAPI.Helpers;
using CVBuilder.WebAPI.Helpers.Enums;
using CVBuilder.WebAPI.Validators;

namespace CVBuilder.WebAPI.Models
{
    public class CertificateModel : SectionModelBase
    {
        public int CertificateId { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string Name { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string Institute { get; set; }
        public bool OnlineMode { get; set; }
        public bool InProgress { get; set; }

        [RequiredIfNot("InProgress")]
        public int? Year { get; set; }
        
        [MaxLength(300, ErrorMessage = ErrorMessages.MAX_LENGTH_300)]
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public int Id_Curriculum { get; set; }
        
        public CertificateModel()
        {
            base.FormId = FormIds.Certificate;
            base.FormMode = FormMode.ADD;
            this.IsVisible = true;
        }
        
        public readonly DateDropdownList Period = new DateDropdownList(DateType.CERTIFICATE);
    }
}