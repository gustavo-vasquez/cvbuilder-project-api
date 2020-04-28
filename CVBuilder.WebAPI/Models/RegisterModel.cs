namespace CVBuilder.WebAPI.Models
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool TermsAndConditions { get; set; }
    }
}