using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonApi
{
    public class PokemonService
    {
        public async Task<Pokemon> GetPokemonByIdAsync(int id, CancellationToken cancellationToken)
        {
            string url = $"https://pokeapi.co/api/v2/pokemon/{id}/";

            Pokemon pokemon = await DeserializeFromWebAsync<Pokemon>(url, cancellationToken);

            return pokemon;
        }

        private async Task<T> DeserializeFromWebAsync<T>(string url, CancellationToken cancellationToken)
        {
            string json;

            using (WebClient webClient = new WebClient())
            {
                json = await webClient.DownloadStringTaskAsync(url);
            }

            T obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);

            return obj;
        }

        public async Task<ResultList<ModelRetriever<Pokemon>>> GetPokemonListAsync(CancellationToken cancellationToken)
        {
            string url = $"https://pokeapi.co/api/v2/pokemon/";

            ResultList<ModelRetriever<Pokemon>> results = await DeserializeFromWebAsync<ResultList<ModelRetriever<Pokemon>>>(url, cancellationToken);

            return results;
        }

    }
}
