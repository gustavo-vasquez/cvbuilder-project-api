using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CVBuilder.WebAPI.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = ErrorMessages.MAX_FILE_SIZE;
        private readonly int _size;

        /// <summary>
        /// El peso máximo del archivo expresado en bytes.
        /// </summary>
        /// <param name="size"></param>
        public MaxFileSizeAttribute(int size) : base (DefaultErrorMessage)
        {
            _size = size;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                IFormFile currentValue = (IFormFile)value;

                if (currentValue.Length > 0 && currentValue.Length > _size)
                    return new ValidationResult(FormatErrorMessage(currentValue.FileName));
            }

            return ValidationResult.Success;
        }
    }
}