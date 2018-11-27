using System;
using System.Threading.Tasks;

namespace PokemonApi.Mobile
{
    public class ActivatorFactory : IFactory
    {
        public Task<object> CreateAsync(Type type)
        {
            return Task.FromResult(Activator.CreateInstance(type));
        }

        public Task<T> CreateAsync<T>()
        {
            return Task.FromResult(Activator.CreateInstance<T>());
        }
    }
}
