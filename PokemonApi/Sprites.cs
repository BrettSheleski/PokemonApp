using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonApi
{
    public class Sprites : ModelBase
    {
        [JsonProperty("back_default")]
        public string BackDefault { get; set; }

        [JsonProperty("back_female")]
        public string BackFemale { get; set; }

        [JsonProperty("back_shiny")]
        public string BackShiny { get; set; }

        [JsonProperty("back_shiny_female")]
        public string BackShinyFemale { get; set; }

        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }

        [JsonProperty("front_female")]
        public string FrontFemale { get; set; }

        [JsonProperty("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonProperty("front_shiny_female")]
        public string FrontShinyFemale { get; set; }

        public IEnumerable<string> AsEnumerable()
        {
            yield return BackDefault;
            yield return BackFemale;
            yield return BackShiny;
            yield return BackShinyFemale;
            yield return FrontDefault;
            yield return FrontFemale;
            yield return FrontShiny;
            yield return FrontShinyFemale;
        }
    }
}