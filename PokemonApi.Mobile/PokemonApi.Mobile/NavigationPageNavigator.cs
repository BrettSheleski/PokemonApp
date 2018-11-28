using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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

        public Task<Page> NavigateToAsync<T>() where T : ViewModelBase
        {
            return NavigateToAsync<T>(null);
        }

        public async Task<Page> NavigateToAsync<T>(Action<T> preInitAction) where T : ViewModelBase
        {
            Type vmType = typeof(T);
            Type pageType;

            if (!RegistryByViewModel.TryGetValue(vmType, out pageType))
            {
                throw new InvalidOperationException();
            }

            Page page = (Page)await PageFactory.CreateAsync(pageType);
            T viewModel = await ViewModelFactory.CreateAsync<T>();

            preInitAction?.Invoke(viewModel);

            page.BindingContext = viewModel;

            await this.NavigationPage.PushAsync(page);

            await viewModel.InitializeAsync(CancellationToken.None);

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
