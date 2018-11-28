using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonApi.Mobile.Pages.Main
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigator navigator)
        {
            this.Navigator = navigator;

            this.ViewPokemonIndexCommand = new AsyncCommand(ViewPokemonIndexAsync);
            this.ViewPokedexIndexCommand = new AsyncCommand(ViewPokedexIndexAsync);
        }

        private Task ViewPokedexIndexAsync()
        {
            return this.Navigator.NavigateToAsync<PokedexIndex.PokedexIndexViewModel>();
        }

        private Task ViewPokemonIndexAsync()
        {
            return this.Navigator.NavigateToAsync<PokemonIndex.PokemonIndexViewModel>();
        }

        public INavigator Navigator { get; }
        public Command ViewPokemonIndexCommand { get; }
        public AsyncCommand ViewPokedexIndexCommand { get; }
    }

    
}
