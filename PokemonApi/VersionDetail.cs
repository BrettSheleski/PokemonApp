using Newtonsoft.Json;

namespace PokemonApi
{
    public class VersionDetail : ModelBase
    {
        [JsonProperty("rarity")]
        public int Rarity { get; set; }

        [JsonProperty("version")]
        public ModelRetriever<Version> Retriever { get; set; }
    }
}