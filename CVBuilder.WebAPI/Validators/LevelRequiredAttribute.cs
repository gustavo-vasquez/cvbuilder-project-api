using CVBuilder.Service.Helpers;
using CVBuilder.WebAPI.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace CVBuilder.WebAPI.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LevelRequiredAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = ErrorMessages.REQUIRED;
        private readonly bool AllowEmptyStrings;

        public LevelRequiredAttribute(bool allowEmptyStrings = false) : base (DefaultErrorMessage)
        {
            AllowEmptyStrings = allowEmptyStrings;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            string currentValue = (string)value;

            if (currentValue == LevelOptions.None || AllowEmptyStrings)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}