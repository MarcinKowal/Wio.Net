namespace Wio.Net
{
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class UserToken
    {
        [JsonProperty("token")]
        public string AuthenticationKey { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
