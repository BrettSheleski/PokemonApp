using Newtonsoft.Json;

namespace PokemonApi
{
    public class VersionGroupDetail : ModelBase
    {
        [JsonProperty("level_learned_at")]
        public int LevelLearnedAt { get; set; }

        [JsonProperty("move_learn_method")]
        public MoveLearnMethod MoveLearnMethod { get; set; }

        [JsonProperty("version_group")]
        public VersionGroup VersionGroup { get; set; }
    }
}