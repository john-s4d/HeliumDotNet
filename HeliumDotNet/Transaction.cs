using Newtonsoft.Json;
using System;

namespace HeliumDotNet
{
    public class Transaction
    {
        [JsonProperty("fee")] public int? Fee { get; set; }
        [JsonProperty("gateway")] public string Gateway { get; set; }
        [JsonProperty("hash")] public string Hash { get; set; }
        [JsonProperty("height")] public long? Height { get; set; }
        [JsonProperty("lat")] public float? Latitude { get; set; }
        [JsonProperty("lng")] public float? Longitude { get; set; }
        [JsonProperty("location")] public string Location { get; set; }
        [JsonProperty("nonce")] public int? Nonce { get; set; }
        [JsonProperty("owner")] public string Owner { get; set; }
        [JsonProperty("payer")] public string Payer { get; set; }
        [JsonProperty("staking_fee")] public long? StakingFee { get; set; }
        [JsonProperty("time")] public long? time { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
    }
}