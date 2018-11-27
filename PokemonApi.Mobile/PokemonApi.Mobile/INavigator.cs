using PokemonApi.Mobile.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonApi.Mobile
{
    public interface INavigator
    {
        Task<Page> NavigateToAsync<T>() where T : ViewModelBase;
    }
}