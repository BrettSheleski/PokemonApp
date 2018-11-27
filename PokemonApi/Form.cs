using Newtonsoft.Json;

namespace PokemonApi
{
    public class Form : ModelBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}