using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonApi.Mobile.Pages.PokedexDetails
{
    public class PokedexDetailsViewModel : ViewModelBase
    {
        public PokedexDetailsViewModel(INavigator navigator)
        {
            this.Navigator = navigator;
            this.SpeciesSelectedCommand = new AsyncCommand<PokemonSpeciesEntry>(SpeciesSelectedAsync);
            this.LocationSelectedCommand = new AsyncCommand<ModelRetriever<Location>>(LocationSelectedAsync);
        }

        private Task LocationSelectedAsync(ModelRetriever<Location> arg)
        {
            return Task.CompletedTask;
        }

        private Task SpeciesSelectedAsync(PokemonSpeciesEntry entry)
        {
            return Task.CompletedTask;
        }

        private Task NavigateToRegion()
        {
            return Navigator.NavigateToAsync<Region.RegionDetailsViewModel>(vm => vm.Retriever = this.Pokedex.Region);
        }

        private ModelRetriever<Pokedex> _retriever;

        public ModelRetriever<Pokedex> Retriever { get => _retriever; set => SetProperty(out _retriever, value); }
        public Pokedex Pokedex { get => _pokedex; set => SetProperty(out _pokedex, value); }
        public INavigator Navigator { get; }
        public AsyncCommand NavigateToRegionCommand { get; }
        public AsyncCommand<PokemonSpeciesEntry> SpeciesSelectedCommand { get; }
        public AsyncCommand<ModelRetriever<Location>> LocationSelectedCommand { get; }
        public string Description { get => _description; set => SetProperty(out _description, value); }
        public PokemonApi.Region Region { get => _region; set => SetProperty(out _region, value); }

        private Pokedex _pokedex;

        private string _description;
        private PokemonApi.Region _region;

        public ObservableCollection<ModelRetriever<Location>> RegionLocations { get; } = new ObservableCollection<ModelRetriever<Location>>();

        public async override Task InitializeAsync(CancellationToken cancellationToken)
        {
            await base.InitializeAsync(cancellationToken);

            this.Pokedex = await Retriever.GetAsync(cancellationToken);

            this.Description = this.Pokedex.Descriptions.Where(x => x.Language.Name == "en").Select(x => x.description).FirstOrDefault();




            this.Region = await Pokedex.Region?.GetAsync(cancellationToken);

            if (this.Region != null)
            {
                foreach (var location in Region.Locations.OrderBy(x => x.Name))
                {
                    this.RegionLocations.Add(location);
                }
            }
        }

    }
}
