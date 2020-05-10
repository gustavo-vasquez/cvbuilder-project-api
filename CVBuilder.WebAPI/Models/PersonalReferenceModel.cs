using System.ComponentModel.DataAnnotations;
using CVBuilder.Core.Helpers;
using CVBuilder.WebAPI.Helpers;
using CVBuilder.WebAPI.Helpers.Enums;

namespace CVBuilder.WebAPI.Models
{
    public class PersonalReferenceModel : SectionModel
    {
        public int PersonalReferenceId { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string Company { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(200, ErrorMessage = ErrorMessages.MAX_LENGTH_200)]
        public string ContactPerson { get; set; }

        [Range(1, 9999, ErrorMessage = ErrorMessages.MAX_RANGE_4)]
        public short? AreaCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Range(1, 9999999999, ErrorMessage = ErrorMessages.MAX_RANGE_10)]
        public int? Telephone { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        public string Email { get; set; }
        public bool IsVisible { get; set; }
        public int Id_Curriculum { get; set; }

        public PersonalReferenceModel()
        {
            base.FormId = FormIds.PersonalReference;
            base.FormMode = FormMode.ADD;
            this.IsVisible = true;
        }
    }
}