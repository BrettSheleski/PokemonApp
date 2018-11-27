using Newtonsoft.Json;

namespace PokemonApi
{
    public class TypeInfo : ModelBase
    {
        [JsonProperty("slot")]
        public int Slot { get; set; }

        [JsonProperty("type")]
        public ModelRetriever<PokemonType> Retriever { get; set; }
    }
}