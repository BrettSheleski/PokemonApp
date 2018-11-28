using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonApi.Mobile.Pages.Region
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [ViewModel(typeof(RegionDetailsViewModel))]
	public partial class RegionDetailsPage : ContentPage
	{
		public RegionDetailsPage ()
		{
			InitializeComponent ();
		}
	}
}