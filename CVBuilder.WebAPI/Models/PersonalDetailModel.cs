using System.ComponentModel.DataAnnotations;
using CVBuilder.Core.Helpers;
using CVBuilder.WebAPI.Helpers;
using CVBuilder.WebAPI.Helpers.Enums;
using CVBuilder.WebAPI.Validators;
using Microsoft.AspNetCore.Http;

namespace CVBuilder.WebAPI.Models
{
    public class PersonalDetailModel : SectionModel
    {
        public int PersonalDetailId { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string Name { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string Email { get; set; }

        public string Profession { get; set; }

        [PostedFileExtensions("jpg,jpeg,png", ErrorMessage = ErrorMessages.POSTED_FILE_EXTENSIONS)]
        [MaxFileSize(1048576)]
        public IFormFile UploadedPhoto { get; set; }

        public string Photo { get; set; }

        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string Address { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string City { get; set; }

        [DataType(DataType.PostalCode)]
        [Range(1, 99999, ErrorMessage = ErrorMessages.MAX_RANGE_5)]
        public int? PostalCode { get; set; }

        [Range(1, 9999, ErrorMessage = ErrorMessages.MAX_RANGE_4)]
        public short? AreaCodeLP { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Range(1, 9999999999, ErrorMessage = ErrorMessages.MAX_RANGE_10)]
        public int? LinePhone { get; set; }

        [Range(1, 9999, ErrorMessage = ErrorMessages.MAX_RANGE_4)]
        public short? AreaCodeMP { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Range(1, 9999999999, ErrorMessage = ErrorMessages.MAX_RANGE_10)]
        public int? MobilePhone { get; set; }
        public int? Day { get; set; }
        public string Month { get; set; }
        public int? Year { get; set; }

        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string Country { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(300, ErrorMessage = ErrorMessages.MAX_LENGTH_300)]
        public string Summary { get; set; }

        [MaxLength(50, ErrorMessage = ErrorMessages.MAX_LENGTH_50)]
        public string SummaryCustomTitle { get; set; }
        public bool SummaryIsVisible { get; set; }

        [MaxLength(300, ErrorMessage = ErrorMessages.MAX_LENGTH_300)]
        public string WebPageUrl { get; set; }

        [MaxLength(300, ErrorMessage = ErrorMessages.MAX_LENGTH_300)]
        public string LinkedInUrl { get; set; }

        [MaxLength(300, ErrorMessage = ErrorMessages.MAX_LENGTH_300)]
        public string GithubUrl { get; set; }

        [MaxLength(300, ErrorMessage = ErrorMessages.MAX_LENGTH_300)]
        public string FacebookUrl { get; set; }

        [MaxLength(300, ErrorMessage = ErrorMessages.MAX_LENGTH_300)]
        public string TwitterUrl { get; set; }
        public int Id_Curriculum { get; set; }

        public PersonalDetailModel()
        {
            base.FormId = FormIds.PersonalDetail;
            base.FormMode = FormMode.ADD;
            this.SummaryIsVisible = true;
        }
    }
}