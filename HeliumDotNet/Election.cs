using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Helium
{
    public class Election
    {
        [JsonProperty("delay")] public int? Delay { get; set; }
        [JsonProperty("hash")] public string Hash { get; set; }
        [JsonProperty("height")] public long? Height { get; set; }
        [JsonProperty("members")] public List<string> Members { get; set; }
        [JsonProperty("proof")] public string Proof { get; set; }
        [JsonProperty("time")] public long? Time { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
    }
}