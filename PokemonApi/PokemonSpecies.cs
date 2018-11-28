using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonApi
{
    public class PokemonSpecies : ModelBase
    {
        [JsonProperty("base_happiness")]
        public int BaseHappiness { get; set; }

        [JsonProperty("capture_rate")]
        public int CaptureRate { get; set; }

        [JsonProperty("color")]
        public ModelRetriever<Color> Color { get; set; }

        [JsonProperty("egg_groups")]
        public List<EggGroup> EggGroups { get; set; }

        [JsonProperty("evolution_chain")]
        public EvolutionChain EvolutionChain { get; set; }

        [JsonProperty("evolves_from_species")]
        public object EvolvesFromSpecies { get; set; }

        [JsonProperty("flavor_text_entries")]
        public List<FlavorTextEntry> FlavorTextEntries { get; set; }

        [JsonProperty("form_descriptions")]
        public List<object> FormDescriptions { get; set; }

        [JsonProperty("forms_switchable")]
        public bool FormsSwitchable { get; set; }

        [JsonProperty("gender_rate")]
        public int GenderRate { get; set; }

        [JsonProperty("genera")]
        public List<Genera> Genera { get; set; }

        [JsonProperty("generation")]
        public Generation Generation { get; set; }

        [JsonProperty("growth_rate")]
        public GrowthRate GrowthRate { get; set; }

        [JsonProperty("habitat")]
        public Habitat Habitat { get; set; }

        [JsonProperty("has_gender_differences")]
        public bool HasGenderDifferences { get; set; }

        [JsonProperty("hatch_counter")]
        public int HatchCounter { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("is_baby")]
        public bool IsBaby { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("names")]
        public List<Name> Names { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("pal_park_encounters")]
        public List<PalParkEncounter> PalParkEncounters { get; set; }

        [JsonProperty("pokedex_numbers")]
        public List<PokedexNumber> PokedexNumbers { get; set; }

        [JsonProperty("shape")]
        public Shape Shape { get; set; }

        [JsonProperty("varieties")]
        public List<Variety> Varieties { get; set; }

    }

    public class Color : ModelBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name")]
        public Name Names { get; set; }

        [JsonProperty("pokemon_species")]
        public List<ModelRetriever<PokemonSpecies>> Species { get; set; }
    }

    public class EggGroup
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class EvolutionChain
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }


    public class Genera
    {
        [JsonProperty("genus")]
        public string Genus { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }
    }


    public class GrowthRate
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Habitat
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }



    public class Area
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class PalParkEncounter
    {
        [JsonProperty("area")]
        public Area Area { get; set; }

        [JsonProperty("base_score")]
        public int BaseScore { get; set; }

        [JsonProperty("rate")]
        public int Rate { get; set; }
    }


    public class PokedexNumber
    {
        [JsonProperty("entry_number")]
        public int EntryNumber { get; set; }

        [JsonProperty("pokedex")]
        public ModelRetriever<Pokedex> pokedex { get; set; }
    }

    public class Shape
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Variety
    {
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("pokemon")]
        public ModelRetriever<Pokemon> Pokemon { get; set; }
    }
}
