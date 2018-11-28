using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonApi.Mobile
{
    public interface INavigator
    {
        Task<Page> NavigateToAsync<T>() where T : ViewModelBase;
        Task<Page> NavigateToAsync<T>(Action<T> preInitAction) where T : ViewModelBase;
    }
}