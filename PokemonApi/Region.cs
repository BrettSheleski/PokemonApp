using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonApi
{
    public class Region : ModelBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("locations")]
        public List<ModelRetriever<Location>> Locations { get; set; }
    }

    public class Location : ModelBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public ModelRetriever<Region> Region { get; set; }
    }
}