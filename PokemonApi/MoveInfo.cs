using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonApi
{
    public class MoveInfo : ModelBase
    {
        [JsonProperty("move")]
        public ModelRetriever<Move> Retriever { get; set; }

        [JsonProperty("version_group_details")]
        public List<VersionGroupDetail> VersionGroupDetails { get; set; }
    }
}