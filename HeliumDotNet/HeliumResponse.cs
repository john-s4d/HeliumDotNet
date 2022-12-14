using Newtonsoft.Json;
using System.Collections.Generic;

namespace HeliumDotNet
{
    public class HeliumResponse<T>
    {
        [JsonProperty("meta")] public Dictionary<string,string> Meta { get; set; }
        [JsonProperty("data")] public T Data { get; set; }
        [JsonProperty("cursor")] public string Cursor { get; set; }
    }
}
