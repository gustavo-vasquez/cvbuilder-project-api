using System.ComponentModel.DataAnnotations;
using CVBuilder.WebAPI.Helpers;
using CVBuilder.WebAPI.Helpers.Enums;

namespace CVBuilder.WebAPI.Models
{
    public class CustomSectionModel : SectionModelBase
    {
        public int CustomSectionId { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string SectionName { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public int Id_Curriculum { get; set; }
        
        public CustomSectionModel()
        {
            base.FormId = FormIds.CustomSection;
            base.FormMode = FormMode.ADD;
            this.IsVisible = true;
        }
    }
}