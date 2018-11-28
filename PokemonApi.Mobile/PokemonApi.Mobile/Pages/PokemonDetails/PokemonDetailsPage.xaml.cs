using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonApi.Mobile.Pages.PokemonDetails
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [ViewModel(typeof(PokemonDetailsViewModel))]
	public partial class PokemonDetailsPage : TabbedPage
	{
		public PokemonDetailsPage ()
		{
			InitializeComponent ();
		}
	}
}