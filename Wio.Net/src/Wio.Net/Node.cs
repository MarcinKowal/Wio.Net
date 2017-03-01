namespace Wio.Net
{
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class Node
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("node_key")]
        public string Key { get; set; }

        [JsonProperty("node_sn")]
        public string Serial { get; set; }

        [JsonProperty("dataxserver")]
        public string ExchangeServer { get; set; }

        [JsonProperty("board")]
        public string BoardType { get; set; }

        [JsonProperty("online")]
        public bool IsOnline { get; set; }

    }
}