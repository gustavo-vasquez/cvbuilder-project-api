using System;
using System.ComponentModel.DataAnnotations;
using CVBuilder.WebAPI.Helpers;

namespace CVBuilder.WebAPI.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class StartYearLessThanAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = ErrorMessages.START_YEAR_LESS_THAN;
        private readonly string _comparisonProperty;

        public StartYearLessThanAttribute(string comparisonProperty) : base (DefaultErrorMessage)
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

            var comparisonValue = (int?)comparisonProperty.GetValue(validationContext.ObjectInstance);

            if (currentValue > comparisonValue && comparisonValue != 0)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}