using System.ComponentModel.DataAnnotations;
using CVBuilder.WebAPI.Helpers;
using CVBuilder.WebAPI.Helpers.Enums;

namespace CVBuilder.WebAPI.Models
{
    public class InterestModel : SectionModelBase
    {
        public int InterestId { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string Name { get; set; }
        public bool IsVisible { get; set; }
        public int Id_Curriculum { get; set; }

        public InterestModel()
        {
            base.FormId = FormIds.Interest;
            base.FormMode = FormMode.ADD;
            this.IsVisible = true;
        }
    }
}