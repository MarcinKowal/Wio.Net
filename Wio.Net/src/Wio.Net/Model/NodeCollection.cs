namespace Wio.Net.Model
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    internal class NodeCollection
    {
        [JsonProperty("nodes")]
        internal List<Node> Nodes { get; set; } 
    }
}
