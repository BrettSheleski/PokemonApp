using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonApi.Mobile.Pages.PokemonIndex
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [ViewModel(typeof(PokemonIndexViewModel))]
	public partial class PokemonIndexPage : ContentPage
	{
		public PokemonIndexPage ()
		{
			InitializeComponent ();
		}
	}
}