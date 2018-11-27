using PokemonApi.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonApi.Mobile
{
    public class NavigationPageNavigator : INavigator
    {
        public NavigationPageNavigator(IFactory viewModelFactory, IFactory pageFactory)
        {
            this.ViewModelFactory = viewModelFactory;
            this.PageFactory = pageFactory;
        }

        public NavigationPage NavigationPage { get; set; }

        public async Task<Page> NavigateToAsync<T>() where T : ViewModelBase
        {
            Type vmType = typeof(T);
            Type pageType;

            if (!RegistryByViewModel.TryGetValue(vmType, out pageType))
            {
                throw new InvalidOperationException();
            }

            Page page = (Page)await PageFactory.CreateAsync(pageType);
            ViewModelBase viewModel = await ViewModelFactory.CreateAsync<T>();

            await viewModel.InitializeAsync();

            page.BindingContext = viewModel;

            await this.NavigationPage.PushAsync(page);

            return page;
        }


        public Dictionary<Type, Type> RegistryByViewModel { get; } = new Dictionary<Type, Type>();
        public Dictionary<Type, Type> RegistryByPage { get; } = new Dictionary<Type, Type>();
        public IFactory ViewModelFactory { get; }
        public IFactory PageFactory { get; }

        internal void RegisterPage(Type pageType, Type viewModelType)
        {
            RegistryByPage[pageType] = viewModelType;
            RegistryByViewModel[viewModelType] = pageType;
        }
    }
}
