using Newtonsoft.Json;

namespace Helium
{
    public class Geocode
    {
        [JsonProperty("short_street")] public string ShortSteet { get; set; }
        [JsonProperty("short_state")] public string ShortState { get; set; }
        [JsonProperty("short_country")] public string ShortCountry { get; set; }
        [JsonProperty("short_city")] public string ShortCity { get; set; }
        [JsonProperty("long_street")] public string LongStreet { get; set; }
        [JsonProperty("long_state")] public string LongState { get; set; }
        [JsonProperty("long_country")] public string LongCountry { get; set; }
        [JsonProperty("long_city")] public string LongCity { get; set; }
        [JsonProperty("city_id")] public string CityId { get; set; }
    }
}