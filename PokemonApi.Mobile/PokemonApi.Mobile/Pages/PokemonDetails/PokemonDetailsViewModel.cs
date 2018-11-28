using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonApi.Mobile.Pages.PokemonDetails
{
    public class PokemonDetailsViewModel : ViewModelBase
    {
        public PokemonDetailsViewModel(INavigator navigator)
        {
            this.Navigator = navigator;

            this.SelectMoveCommand = new AsyncCommand<ModelRetriever<PokemonApi.Move>>(SelectMoveAsync);
            this.SelectAbilityCommand = new AsyncCommand<ModelRetriever<Ability>>(SelectAbilityAsync);
            this.SelectFormCommand = new AsyncCommand<ModelRetriever<Form>>(SelectFormAsync);

        }

        private Task SelectFormAsync(ModelRetriever<Form> arg)
        {
            return Task.CompletedTask;
        }

        private Task SelectAbilityAsync(ModelRetriever<Ability> arg)
        {
            return Task.CompletedTask;
        }

        private async Task SelectMoveAsync(ModelRetriever<PokemonApi.Move> moveRetriever)
        {
            await this.Navigator.NavigateToAsync<Move.MoveViewModel>(vm => vm.Retriever = moveRetriever);
        }

        public ModelRetriever<Pokemon> Retriever { get; set; }
        public string Title { get => _title; set => SetProperty(out _title, value); }
        public bool IsLoading { get => _isLoading; set => SetProperty(out _isLoading, value); }
        public Pokemon Pokemon { get => _pokemon; set => SetProperty(out _pokemon, value); }
        public ImageSource[] Images { get => _images; set => SetProperty(out _images, value); }
        public MoveInfo SelectedMove { get => _selectedMove; set => SetProperty(out _selectedMove, value); }
        public INavigator Navigator { get; }
        public AsyncCommand<ModelRetriever<PokemonApi.Move>> SelectMoveCommand { get; }
        public AsyncCommand<ModelRetriever<Ability>> SelectAbilityCommand { get; }
        public AsyncCommand<ModelRetriever<Form>> SelectFormCommand { get; }

        private ImageSource[] _images;

        Pokemon _pokemon;

        private string _title;

        private bool _isLoading;

        private MoveInfo _selectedMove;

        public async override Task InitializeAsync(CancellationToken cancellationToken)
        {
            Title = Retriever.Name;
            try
            {
                IsLoading = true;


                this.Pokemon = await Retriever.GetAsync(cancellationToken);

                this.Images = Pokemon.Sprites?.AsEnumerable().Where(x => x != null).Select(x => ImageSource.FromUri(new Uri(x))).ToArray();



            }
            finally
            {
                IsLoading = false;
            }
            await base.InitializeAsync(cancellationToken);

        }


    }
}
