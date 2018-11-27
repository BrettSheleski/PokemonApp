using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonApi
{
    public class ModelBase
    {
        protected List<T> GetList<T>(ref List<T> _listRef)
        {
            return _listRef ?? (_listRef = new List<T>());
        }

        protected static async Task<T> DeserializeFromWebAsync<T>(string url, CancellationToken cancellationToken)
        {
            string json;

            using (WebClient webClient = new WebClient())
            {
                json = await webClient.DownloadStringTaskAsync(url);
            }

            T obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);

            return obj;
        }
    }
}