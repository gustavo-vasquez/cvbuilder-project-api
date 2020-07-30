using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CVBuilder.Core.Helpers;
using CVBuilder.Service.Helpers;
using CVBuilder.WebAPI.Helpers;
using CVBuilder.WebAPI.Helpers.Enums;
using CVBuilder.WebAPI.Validators;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CVBuilder.WebAPI.Models
{
    public class LanguageModel : SectionModel
    {
        public readonly List<SelectListItem> Levels;

        public int LanguageId { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string Name { get; set; }

        [LevelRequired(ErrorMessage = ErrorMessages.LEVEL_REQUIRED)]
        public string Level { get; set; }
        public bool IsVisible { get; set; }
        public int Id_Curriculum { get; set; }

        public LanguageModel()
        {
            base.FormId = FormIds.Language;
            base.FormMode = FormMode.ADD;
            this.IsVisible = true;
            //Levels = LevelsBox();
        }

        private List<SelectListItem> LevelsBox()
        {
            List<SelectListItem> levels = new List<SelectListItem>();
            levels.Add(new SelectListItem() { Value = LevelOptions.None, Text = "Nivel" });

            foreach (KeyValuePair<string, string> level in LevelOptions.LevelComboBox)
                levels.Add(new SelectListItem() { Value = level.Key, Text = level.Value });

            return levels;
        }
    }
}