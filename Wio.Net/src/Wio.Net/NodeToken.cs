namespace Wio.Net
{
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class NodeToken
    {
        [JsonProperty("node_key")]
        public string Key { get; set; }

        [JsonProperty("node_sn")]
        public string SerialNumber { get; set; }
    }
}
