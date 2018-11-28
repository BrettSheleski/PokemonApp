using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonApi.Mobile.Pages.Main
{
    [ViewModel(typeof(MainPageViewModel))]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
	}
}
