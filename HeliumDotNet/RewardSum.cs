using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Helium
{
    public class RewardSum
    {
        [JsonProperty("max_time")] public DateTime? MaxTime { get; set; }
        [JsonProperty("min_time")] public DateTime? MinTime { get; set; }
        [JsonProperty("bucket")] public string? Bucket { get; set; }
        [JsonProperty("data")] public List<string> Data { get; set; }

    }
}
