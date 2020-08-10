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
        private readonly string[] _mimeTypes;

        /// <summary>
        /// Extensiones tipo MIME de archivo permitidas (separadas por coma).
        /// </summary>
        /// <param name="mimeTypes"></param>
        public PostedFileExtensionsAttribute(string mimeTypes) : base (DefaultErrorMessage)
        {
            _mimeTypes = mimeTypes.Split(',');
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                IFormFile currentValue = (IFormFile)value;
                string mimeType = currentValue.ContentType;
                //string extension = Path.GetExtension(currentValue.FileName).ToLower().Replace(".", "");

                if (!_mimeTypes.Contains(mimeType))
                    return new ValidationResult(FormatErrorMessage(currentValue.ContentType));
            }

            return ValidationResult.Success;
        }
    }
}