using Newtonsoft.Json;

namespace PokemonApi
{
    public class AbilityInfo : ModelBase
    {
        [JsonProperty("ability")]
        public ModelRetriever<Ability> Retriever { get; set; }

        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonProperty("slot")]
        public int Slot { get; set; }
    }
}