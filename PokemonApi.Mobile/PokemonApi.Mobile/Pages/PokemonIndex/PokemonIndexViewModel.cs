using PokemonApi.Extensions;
using PokemonApi.Mobile.Pages.Main;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonApi.Mobile.Pages.PokemonIndex
{
    public class PokemonIndexViewModel : ViewModelBase
    {
        public PokemonIndexViewModel(PokemonApi.PokemonService pokemonService, INavigator navigator)
        {
            this.PokemonService = pokemonService;
            this.Navigator = navigator;
            this.UpdateFilteredPokemonCommand = new AsyncCommand(UpdateFilteredPokemonAsync);
        }

        private bool _isLoading;
        private string _searchText;

        public override async Task InitializeAsync(CancellationToken cancellationToken)
        {
            try
            {
                IsLoading = true;

                await base.InitializeAsync(cancellationToken);

                var result = await this.PokemonService.GetPokemonListAsync(cancellationToken);

                foreach (var item in result.Results.OrderBy(x => x.Name))
                {
                    this.AllPokemon.Add(item);
                }

                await UpdateFilteredPokemonAsync();
            }
            finally
            {
                IsLoading = false;
            }
        }

        public ObservableCollection<ModelRetriever<Pokemon>> AllPokemon { get; } = new ObservableCollection<ModelRetriever<Pokemon>>();
        public ObservableCollection<ModelRetriever<Pokemon>> FilteredPokemon { get; } = new ObservableCollection<ModelRetriever<Pokemon>>();
        public ModelRetriever<Pokemon> SelectedPokemon
        {
            get => _selectedPokemon; set
            {
                SetProperty(out _selectedPokemon, value);

                if (value != null)
                {
                    this.Navigator.NavigateToAsync<PokemonDetails.PokemonDetailsViewModel>(x => x.Retriever = value);

                    SelectedPokemon = null;
                }
            }
        }

        public PokemonService PokemonService { get; }
        public INavigator Navigator { get; }
        public Command UpdateFilteredPokemonCommand { get; }
        public bool IsLoading { get => _isLoading; set => SetProperty(out _isLoading, value); }
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(out _searchText, value);
            }
        }

        public bool IsFiltering { get => _isFiltering; set => SetProperty(out _isFiltering, value); }

        static readonly char[] searchSeparators = new char[] { ' ' };

        private bool _isFiltering = false;

        private Task UpdateFilteredPokemonAsync()
        {
            return Task.Factory.StartNew(UpdateFilteredPokemon);
        }

        private void UpdateFilteredPokemon()
        {
            Func<ModelRetriever<Pokemon>, bool> filter = x => true;

            

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                var words = SearchText.Split(searchSeparators, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    filter = filter.And(x => x.Name.Contains(word));
                }
            }

            int nextIndex = 0;
            int currentIndex;
            foreach (var pokemon in AllPokemon)
            {
                if (filter(pokemon))
                {
                    if (FilteredPokemon.Contains(pokemon))
                    {
                        currentIndex = FilteredPokemon.IndexOf(pokemon);

                        FilteredPokemon.Move(currentIndex, nextIndex);
                    }
                    else
                    {
                        FilteredPokemon.Insert(nextIndex, pokemon);
                    }

                    ++nextIndex;
                }
                else if (FilteredPokemon.Contains(pokemon))
                {
                    FilteredPokemon.Remove(pokemon);
                }
            }
        }

        private ModelRetriever<Pokemon> _selectedPokemon;
    }
}
