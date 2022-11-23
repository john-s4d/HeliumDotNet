using Newtonsoft.Json;

namespace Helium
{
    public class HeliumResponse<T>
    {
        [JsonProperty("data")] public T Data { get; set; }
        [JsonProperty("cursor")] public string Cursor { get; set; }
    }
}
