using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonApi.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigator navigator)
        {
            this.Navigator = navigator;

            this.ViewPokemonIndexCommand = new AsyncCommand(ViewPokemonIndexAsync);
        }

        private Task ViewPokemonIndexAsync()
        {
            return this.Navigator.NavigateToAsync<PokemonIndex.PokemonIndexViewModel>();
        }

        public INavigator Navigator { get; }
        public Command ViewPokemonIndexCommand { get; }
    }

    public class AsyncCommand : Command
    {
        public AsyncCommand(Func<Task> asyncFunc) : base(async () => await asyncFunc())
        {

        }
    }
}
