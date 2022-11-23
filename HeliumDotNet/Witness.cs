using Newtonsoft.Json;
using System;

namespace Helium
{
    public class Witness
    {
        [JsonProperty("receipt")] public Receipt Receipt { get; set; }
        [JsonProperty("geocode")] public Geocode Geocode { get; set; }
        [JsonProperty("challengee_owner")] public string ChallengeeOwner { get; set; }
        [JsonProperty("challengee_lon")] public float? ChallengeeLongitude { get; set; }
        [JsonProperty("challengee_location")] public string ChallengeeLocation { get; set; }
        [JsonProperty("challengee_lat")] public float? ChallengeeLatitude { get; set; }
        [JsonProperty("challengee")] public string Challengee { get; set; }
    }
}