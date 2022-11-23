using System;
using Newtonsoft.Json;

namespace Helium
{
    public class Hotspot
{
        [JsonProperty("lng")] public float? Longitude { get; set; }
        [JsonProperty("lat")] public float? Latitude { get; set; }
        [JsonProperty("timestamp_added")] public DateTime? TimestampAdded { get; set; }
        [JsonProperty("status")] public Status Status { get; set; }
        [JsonProperty("reward_scale")] public float? RewardScale { get; set; }
        [JsonProperty("payer")] public string Payer { get; set; }
        [JsonProperty("owner")] public string Owner { get; set; }
        [JsonProperty("nonce")] public int Nonce { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("mode")] public string Mode { get; set; }
        [JsonProperty("location_hex")] public string LocationHex { get; set; }
        [JsonProperty("location")] public string Location { get; set; }
        [JsonProperty("last_poc_challenge")] public long? LastPocChallenge { get; set; }
        [JsonProperty("last_change_block")] public long? LastChangeBlock { get; set; }
        [JsonProperty("geocode")] public Geocode Geocode { get; set; }
        [JsonProperty("gain")] public float? Gain { get; set; }
        [JsonProperty("elevation")] public float? Elevation { get; set; }
        [JsonProperty("block_added")] public long? BlockAdded { get; set; }
        [JsonProperty("block")] public long? Block { get; set; }
        [JsonProperty("address")] public string Address { get; set; }
        [JsonProperty("score_update_height")] public long? ScoreUpdateHeight { get; set; }
        [JsonProperty("score")] public float? Score { get; set; }
    }
}
