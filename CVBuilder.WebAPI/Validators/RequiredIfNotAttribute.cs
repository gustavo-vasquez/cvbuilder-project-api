using System;
using System.ComponentModel.DataAnnotations;

namespace CVBuilder.WebAPI.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class RequiredIfNotAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = ErrorMessages.REQUIRED;
        private readonly string _comparisonProperty;

        public RequiredIfNotAttribute(string comparisonProperty) : base (DefaultErrorMessage)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            int? currentValue = (int?)value;
            var comparisonProperty = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (comparisonProperty == null)
                throw new ArgumentException("No existe una propiedad con el nombre" + comparisonProperty + ".");

            var comparisonValue = (bool)comparisonProperty.GetValue(validationContext.ObjectInstance);

            if (!comparisonValue && currentValue == 0)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}