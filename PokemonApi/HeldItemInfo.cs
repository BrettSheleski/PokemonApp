using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonApi
{
    public class HeldItemInfo : ModelBase
    {
        [JsonProperty("item")]
        public ModelRetriever<ModelRetriever<Item>> Retriever { get; set; }

        [JsonProperty("version_details")]
        public List<VersionDetail> VersionDetails { get; set; }
    }
}