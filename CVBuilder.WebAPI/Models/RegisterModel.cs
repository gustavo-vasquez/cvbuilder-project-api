using System.ComponentModel.DataAnnotations;
using CVBuilder.WebAPI.Helpers;

namespace CVBuilder.WebAPI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MinLength(6, ErrorMessage = ErrorMessages.MIN_LENGTH_6)]
        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        public string Password { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        [MaxLength(100, ErrorMessage = ErrorMessages.MAX_LENGTH_100)]
        [Compare("Password", ErrorMessage = ErrorMessages.COMPARE_PASSWORD)]
        public string ConfirmPassword { get; set; }
        
        [Range(typeof(bool), "true", "true", ErrorMessage = ErrorMessages.TERMS_AND_CONDITIONS)]
        public bool TermsAndConditions { get; set; }
    }
}