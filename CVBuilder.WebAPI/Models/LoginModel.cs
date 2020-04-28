using System.ComponentModel.DataAnnotations;
using CVBuilder.WebAPI.Validators;

namespace CVBuilder.WebAPI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMessages.REQUIRED)]
        public string Password { get; set; }
    }
}