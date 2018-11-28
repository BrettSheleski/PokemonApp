using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonApi
{
    public class Form : ModelBase
    {
        [JsonProperty("form_name")]
        public string FormName { get; set; }

        [JsonProperty("form_names")]
        public List<object> FormNames { get; set; }

        [JsonProperty("form_order")]
        public int FormOrder { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("is_battle_only")]
        public bool IsBattleOnlye { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("is_mega")]
        public bool IsMega { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("names")]
        public List<object> Names { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("pokemon")]
        public ModelRetriever<Pokemon> Pokemon { get; set; }

        [JsonProperty("sprites")]
        public Sprites Sprites { get; set; }

        [JsonProperty("version_group")]
        public VersionGroup VersionGroup { get; set; }
    }
}