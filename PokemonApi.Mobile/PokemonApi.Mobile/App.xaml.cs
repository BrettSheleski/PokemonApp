using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace PokemonApi.Mobile
{
	public partial class App : Application
	{
        public IContainer Container { get; }

        public App ()
		{
			InitializeComponent();


            AutoFacFactory autoFacFactory = new AutoFacFactory();
            ActivatorFactory activatorFactory = new ActivatorFactory();

            NavigationPageNavigator navigator = new NavigationPageNavigator(autoFacFactory, activatorFactory);

            MainPage mainPage = new MainPage()
            {

            };

            NavigationPage navPage = new NavigationPage(mainPage);

            navigator.NavigationPage = navPage;

            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterInstance<INavigator>(navigator).SingleInstance();

            var thisAssembly = this.GetType().Assembly;

            navigator.RegisterPage(typeof(MainPage), typeof(ViewModels.MainPageViewModel));
            navigator.RegisterPage(typeof(PokemonIndex.PokemonIndexPage), typeof(PokemonIndex.PokemonIndexViewModel));

            //RegisterPagesWithNavigator(navigator, thisAssembly);

            RegisterViewModels(containerBuilder, thisAssembly);

            containerBuilder.RegisterType<PokemonApi.PokemonService>();

            this.Container = containerBuilder.Build(Autofac.Builder.ContainerBuildOptions.None);

            autoFacFactory.Container = Container;

            mainPage.BindingContext = Container.Resolve<ViewModels.MainPageViewModel>();

            MainPage = navPage;
		}

        static readonly Type pageType = typeof(Page);

        private void RegisterPagesWithNavigator(NavigationPageNavigator navigator, Assembly assembly)
        {
            var pageTypes = assembly.GetExportedTypes()
                                  .Where(t => pageType.IsAssignableFrom(t))
                                  .Where(t => !t.IsAbstract)
                                  .ToList();

            Type vmType;
            foreach(var pageType in pageTypes)
            {
                var x = pageType.GetCustomAttribute<ViewModelAttribute>();

                if (x != null)
                {
                    navigator.RegisterPage(pageType, x.ViewModelType);
                }
            }

        }

        static readonly Type viewModelBaseType = typeof(ViewModels.ViewModelBase);

        private void RegisterViewModels(ContainerBuilder containerBuilder, System.Reflection.Assembly assembly)
        {
            var vmTypes = assembly.GetExportedTypes()
                                  ?.Where(t => viewModelBaseType.IsAssignableFrom(t))
                                  ?.Where(t => !t.IsAbstract)
                                  ?.ToList() 
                                  ?? new List<Type>();

            foreach(var vmType in vmTypes)
            {
                containerBuilder.RegisterType(vmType);
            }

        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
