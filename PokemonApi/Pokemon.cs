using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonApi
{
    public class Pokemon : ModelBase
    {
        private List<AbilityInfo> _abilities;
        private List<Form> _forms;
        private List<GameIndex> _gameIndices;
        private List<HeldItemInfo> _heldItems;
        private List<MoveInfo> _moves;
        private List<Stat> _stats;
        private List<TypeInfo> _types;

        [JsonProperty("abilities")]
        public List<AbilityInfo> Abilities { get => GetList(ref _abilities); set => _abilities = value; }

        [JsonProperty("base_experience")]
        public int BaseExperience { get; set; }

        [JsonProperty("forms")]
        public List<Form> Forms { get => GetList(ref _forms); set => _forms = value; }

        [JsonProperty("game_indices")]
        public List<GameIndex> GameIndices { get => GetList(ref _gameIndices); set => _gameIndices = value; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("held_items")]
        public List<HeldItemInfo> HeldItems { get => GetList(ref _heldItems); set => _heldItems = value; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("location_area_encounters")]
        public string LocationAreaEncounters { get; set; }

        [JsonProperty("moves")]
        public List<MoveInfo> Moves { get => GetList(ref _moves); set => _moves = value; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("species")]
        public Species Species { get; set; }

        [JsonProperty("sprites")]
        public Sprites Sprites { get; set; }

        [JsonProperty("stats")]
        public List<Stat> Stats { get => GetList(ref _stats); set => _stats = value; }

        [JsonProperty("types")]
        public List<TypeInfo> Types { get => GetList(ref _types); set => _types = value; }

        [JsonProperty("weight")]
        public int Weight { get; set; }
    }
}