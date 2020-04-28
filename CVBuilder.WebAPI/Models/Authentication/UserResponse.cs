using CVBuilder.WebAPI.Helpers.Enums;
using Newtonsoft.Json;

namespace CVBuilder.WebAPI.Models.Authentication
{
    public class UserResponse
    {
        [JsonProperty(UserClaims.EMAIL)]
        public string Email { get; set; }

        [JsonProperty(UserClaims.PHOTO)]
        public string Photo { get; set; }

        [JsonProperty(UserClaims.ACCESSDATE)]
        public string AccessDate { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}