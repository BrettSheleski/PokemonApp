using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonApi.Mobile
{
    public interface IFactory
    {
        Task<object> CreateAsync(Type type);
        Task<T> CreateAsync<T>();
    }
}