using CVBuilder.Service.Helpers;
using CVBuilder.WebAPI.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace CVBuilder.WebAPI.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class YearPeriodRequiredAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = ErrorMessages.YEAR_PERIOD_REQUIRED;
        private readonly string _comparisonProperty;

        public YearPeriodRequiredAttribute(string comparisonProperty) : base (DefaultErrorMessage)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            int? currentValue = (int?)value;

            var comparisonProperty = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (comparisonProperty == null)
                throw new ArgumentException("No existe una propiedad con este nombre.");

            var comparisonValue = (string)comparisonProperty.GetValue(validationContext.ObjectInstance);

            if (currentValue == 0 && comparisonValue != MonthOptions.NotShow && comparisonValue != MonthOptions.Present)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}