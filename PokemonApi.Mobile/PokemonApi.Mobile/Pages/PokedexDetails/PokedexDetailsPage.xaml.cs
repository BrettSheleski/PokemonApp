using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonApi.Mobile.Pages.PokedexDetails
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [ViewModel(typeof(PokedexDetailsViewModel))]
	public partial class PokedexDetailsPage : TabbedPage
	{
		public PokedexDetailsPage ()
		{
			InitializeComponent ();
		}
	}
}