namespace Wio.Net.Model
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class WellKnown
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("well_known")]
        public List<string> SupportedRquests { get; set; }
    }
}
