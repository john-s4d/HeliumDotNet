using System;
using Newtonsoft.Json;

namespace HeliumDotNet
{
    public class RewardSum
    {
        [JsonProperty("total")] public decimal Total { get; set; }
        [JsonProperty("timestamp")] public DateTime Timestamp { get; set; }
        [JsonProperty("sum")] public decimal Sum { get; set; }
        [JsonProperty("stddev")] public decimal Stddev { get; set; }
        [JsonProperty("min")] public decimal Min { get; set; }
        [JsonProperty("median")] public decimal Median { get; set; }
        [JsonProperty("max")] public decimal Max { get; set; }
        [JsonProperty("avg")] public decimal Avg { get; set; }
    }
}
