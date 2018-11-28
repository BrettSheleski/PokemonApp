using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace PokemonApi.Mobile
{
    public class AutoFacFactory : IFactory
    {
        public AutoFacFactory()
        {

        }

        public AutoFacFactory(IContainer container)
        {
            this.Container = container;
        }

        public IContainer Container { get; set; }

        public Task<object> CreateAsync(Type type)
        {
            return Task.FromResult(Container.Resolve(type));
        }

        public Task<T> CreateAsync<T>()
        {
            return Task.FromResult(Container.Resolve<T>());
        }
    }
}
