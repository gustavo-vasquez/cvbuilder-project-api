using System;
using System.ComponentModel.DataAnnotations;
using CVBuilder.Service.Helpers;
using CVBuilder.WebAPI.Helpers;

namespace CVBuilder.WebAPI.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class EndYearGreaterThanAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = ErrorMessages.END_YEAR_GREATER_THAN;
        private readonly string _comparisonProperty;

        public EndYearGreaterThanAttribute(string comparisonProperty) : base (DefaultErrorMessage)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            int? currentValue = (int?)value;

            var comparisonProperty = validationContext.ObjectType.GetProperty(_comparisonProperty);
            var endMonthProperty = validationContext.ObjectType.GetProperty("EndMonth");

            if (comparisonProperty == null)
                throw new ArgumentException("No existe una propiedad con este nombre.");
            if (endMonthProperty == null)
                throw new ArgumentException("No existe la propiedad llamada EndMonth.");

            var comparisonValue = (int?)comparisonProperty.GetValue(validationContext.ObjectInstance);
            var endMonthValue = (string)endMonthProperty.GetValue(validationContext.ObjectInstance);

            if (currentValue < comparisonValue && comparisonValue != 0 && endMonthValue != MonthOptions.Present)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}