using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApi
{

    public class Description
    {
        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }
    }


    public class Name
    {
        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class PokemonSpeciesEntry
    {
        [JsonProperty("entry_number")]
        public int EntryNumber { get; set; }

        [JsonProperty("pokemon_species")]
        public ModelRetriever<PokemonSpecies> Species { get; set; }
    }

    public class Pokedex : ModelBase
    {
        private List<PokemonSpeciesEntry> _species;
        private List<object> _versionGroups;
        private List<Description> _descriptions;
        private List<Name> _names;

        [JsonProperty("descriptions")]
        public List<Description> Descriptions { get => GetList(ref _descriptions); set => _descriptions = value; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("is_main_series")]
        public bool IsMainSeries { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("names")]
        public List<Name> Names { get => GetList(ref _names); set => _names = value; }



        [JsonProperty("pokemon_entries")]
        public List<PokemonSpeciesEntry> Species { get => GetList(ref _species); set => _species = value; }

        [JsonProperty("region")]
        public ModelRetriever<Region> Region { get; set; }

        [JsonProperty("version_groups")]
        public List<object> VersionGroups { get => GetList(ref _versionGroups); set => _versionGroups = value; }
    }


}
