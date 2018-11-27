using PokemonApi.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonApi.Mobile.PokemonIndex
{
    public class PokemonIndexViewModel : ViewModelBase
    {
        public PokemonIndexViewModel(PokemonApi.PokemonService pokemonService, INavigator navigator)
        {
            this.PokemonService = pokemonService;
            this.Navigator = navigator;
        }

        public override async Task InitializeAsync(CancellationToken cancellationToken)
        {
            await base.InitializeAsync(cancellationToken);

            var result = await this.PokemonService.GetPokemonListAsync(cancellationToken);

            foreach (var item in result.Results)
            {
                this.Pokemon.Add(item);
            }
        }

        public ObservableCollection<ModelRetriever<Pokemon>> Pokemon { get; } = new ObservableCollection<ModelRetriever<Pokemon>>();
        public ModelRetriever<Pokemon> SelectedPokemon
        {
            get => _selectedPokemon; set
            {
                SetProperty(out _selectedPokemon, value);

                if (value != null)
                {
                    this.Navigator.NavigateToAsync<Pokedex.PokedexViewModel>(x => x.Retriever = value);

                    SelectedPokemon = null;
                }
            }
        }

        public PokemonService PokemonService { get; }
        public INavigator Navigator { get; }

        private ModelRetriever<Pokemon> _selectedPokemon;
    }
}
