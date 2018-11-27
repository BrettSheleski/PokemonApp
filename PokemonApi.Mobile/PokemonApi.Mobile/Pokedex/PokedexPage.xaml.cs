using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonApi.Mobile.Pokedex
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [ViewModel(typeof(PokedexViewModel))]
	public partial class PokedexPage : ContentPage
	{
		public PokedexPage ()
		{
			InitializeComponent ();
		}
	}
}