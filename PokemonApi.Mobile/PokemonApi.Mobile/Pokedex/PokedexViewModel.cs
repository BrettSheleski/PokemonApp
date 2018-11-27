using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonApi.Mobile.Pokedex
{
    class PokedexViewModel : ViewModels.ViewModelBase
    {
        public ModelRetriever<Pokemon> Retriever { get; set; }

        public async override Task InitializeAsync(CancellationToken cancellationToken)
        {
            await base.InitializeAsync(cancellationToken);



        }
    }
}
