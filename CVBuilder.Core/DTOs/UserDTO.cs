namespace CVBuilder.Core.DTOs
{
    public class UserDTO
    {
        public string Email { get; set; }
        //public string Photo { get; set; }
        public string AccessDate { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}