using System;
using Newtonsoft.Json;

namespace HeliumDotNet
{
    public class Status
    {
        [JsonProperty("timestamp")] public DateTime? Timestamp { get; set; }
        [JsonProperty("online")] public string Online { get; set; }
        [JsonProperty("listen_addrs")] public string[] ListenAddress { get; set; }
        [JsonProperty("height")] public long? Height { get; set; }
    }
}
