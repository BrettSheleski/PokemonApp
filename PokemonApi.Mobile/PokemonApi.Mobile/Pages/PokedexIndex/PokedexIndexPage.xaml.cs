using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonApi.Mobile.Pages.PokedexIndex
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [ViewModel(typeof(PokedexIndexViewModel))]
	public partial class PokedexIndexPage : ContentPage
	{
		public PokedexIndexPage ()
		{
			InitializeComponent ();
		}
	}
}