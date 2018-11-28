using System.Linq;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace PokemonApi.Mobile.Pages.PokedexIndex
{
    public class PokedexIndexViewModel : ViewModelBase
    {
        public PokedexIndexViewModel(PokemonService pokemonService, INavigator navigator)
        {
            this.PokemonService = pokemonService;
            this.Navigator = navigator;

            this.PokedexSelectedCommand = new AsyncCommand<ModelRetriever<PokemonApi.Pokedex>>(PokedexSelectedAsync);
        }

        private Task PokedexSelectedAsync(ModelRetriever<PokemonApi.Pokedex> retriever)
        {
            return this.Navigator.NavigateToAsync<PokedexDetails.PokedexDetailsViewModel>(vm => vm.Retriever = retriever);
        }

        public PokemonService PokemonService { get; }
        public INavigator Navigator { get; }
        public AsyncCommand<ModelRetriever<PokemonApi.Pokedex>> PokedexSelectedCommand { get; }

        public async override Task InitializeAsync(CancellationToken cancellationToken)
        {
            await base.InitializeAsync(cancellationToken);

            foreach(var pokedex in (await PokemonService.GetPokedexListAsync(cancellationToken)).Results.OrderBy(x => x.Name))
            {
                this.Pokedexes.Add(pokedex);
            }
        }

        public ObservableCollection<ModelRetriever<PokemonApi.Pokedex>> Pokedexes { get; } = new ObservableCollection<ModelRetriever<PokemonApi.Pokedex>>();



    }
}