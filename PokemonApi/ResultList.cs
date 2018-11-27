using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonApi
{
    public class ResultList<T> : ModelBase
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }
}
