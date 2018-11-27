using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonApi
{
    public class ModelRetriever<T> : ModelBase where T : ModelBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public Task<T> GetAsync(CancellationToken cancellationToken)
        {
            return DeserializeFromWebAsync<T>(this.Url, cancellationToken);
        }
    }
}