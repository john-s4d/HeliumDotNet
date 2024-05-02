using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HeliumDotNet
{
    public class Receipt
    {
        [JsonProperty("type")] public string Type { get; set; }
        [JsonProperty("time")] public long? Time { get; set; }
        [JsonProperty("secret")] public string Secret { get; set; }
        [JsonProperty("path")] public List<Witness> Path { get; set; }
         
    }
}