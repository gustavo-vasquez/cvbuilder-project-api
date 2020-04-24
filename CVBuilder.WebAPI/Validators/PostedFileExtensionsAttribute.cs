using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace CVBuilder.WebAPI.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PostedFileExtensionsAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "Extensión de archivo no permitida.";
        private readonly string[] _extensions;

        /// <summary>
        /// Extensiones de archivo permitidas (separadas por coma).
        /// </summary>
        /// <param name="extensions"></param>
        public PostedFileExtensionsAttribute(string extensions) : base (DefaultErrorMessage)
        {
            _extensions = extensions.Split(',');
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                IFormFile currentValue = (IFormFile)value;
                string extension = Path.GetExtension(currentValue.FileName).ToLower().Replace(".", "");

                if (!_extensions.Contains(extension))
                    return new ValidationResult(FormatErrorMessage(currentValue.FileName));
            }

            return ValidationResult.Success;
        }
    }
}