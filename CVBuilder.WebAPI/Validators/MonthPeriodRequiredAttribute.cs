using System;
using System.ComponentModel.DataAnnotations;
using CVBuilder.Service.Helpers;

namespace CVBuilder.WebAPI.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MonthPeriodRequiredAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = ErrorMessages.MONTH_PERIOD_REQUIRED;

        public MonthPeriodRequiredAttribute() : base (DefaultErrorMessage)
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            string currentValue = (string)value;

            if (currentValue == MonthOptions.None)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}