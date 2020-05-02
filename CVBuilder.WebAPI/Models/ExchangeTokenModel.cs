using Newtonsoft.Json;

namespace CVBuilder.WebAPI.Models
{
    public class ExchangeTokenModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get;set; }
    }
}