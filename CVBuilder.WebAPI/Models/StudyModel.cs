using System.ComponentModel.DataAnnotations;
using CVBuilder.WebAPI.Helpers;
using CVBuilder.WebAPI.Helpers.Enums;
using CVBuilder.WebAPI.Validators;

namespace CVBuilder.WebAPI.Models
{
    public class StudyModel : SectionModel
    {
        public int StudyId { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string Title { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string Institute { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string City { get; set; }

        [MonthPeriodRequired]
        public string StartMonth { get; set; }
        
        [YearPeriodRequired("StartMonth")]
        [StartYearLessThan("EndYear")]
        public int? StartYear { get; set; }

        [MonthPeriodRequired]
        public string EndMonth { get; set; }

        [YearPeriodRequired("EndMonth")]
        [EndYearGreaterThan("StartYear")]
        public int? EndYear { get; set; }

        [MaxLength(300, ErrorMessage = ErrorMessages.MAX_LENGTH_300)]
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public int Id_Curriculum { get; set; }
        
        public StudyModel()
        {
            base.FormId = FormIds.Study;
            base.FormMode = FormMode.ADD;
            this.IsVisible = true;
        }

        public readonly DateDropdownList StartPeriod = new DateDropdownList(DateType.START_PERIOD);
        public readonly DateDropdownList EndPeriod = new DateDropdownList(DateType.END_PERIOD);
    }
}