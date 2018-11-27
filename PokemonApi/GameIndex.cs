using Newtonsoft.Json;

namespace PokemonApi
{
    public class GameIndex : ModelBase
    {
        [JsonProperty("game_index")]
        public int Id { get; set; }

        [JsonProperty("version")]
        public ModelRetriever<Version> Version { get; set; }
    }
}