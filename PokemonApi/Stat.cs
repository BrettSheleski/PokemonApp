using Newtonsoft.Json;

namespace PokemonApi
{
    public class Stat : ModelBase
    {
        [JsonProperty("base_stat")]
        public int BaseStat { get; set; }

        [JsonProperty("effort")]
        public int Effort { get; set; }

        [JsonProperty("stat")]
        public Stat2 Stat2 { get; set; }
    }
}