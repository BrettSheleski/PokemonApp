using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PokemonApi.Mobile
{
    public partial class App : Application
    {
        public IContainer Container { get; }

        public App()
        {
            InitializeComponent();


            AutoFacFactory autoFacFactory = new AutoFacFactory();
            ActivatorFactory activatorFactory = new ActivatorFactory();

            NavigationPageNavigator navigator = new NavigationPageNavigator(autoFacFactory, activatorFactory);

            Pages.Main.MainPage mainPage = new Pages.Main.MainPage()
            {

            };

            NavigationPage navPage = new NavigationPage(mainPage);

            navigator.NavigationPage = navPage;

            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterInstance<INavigator>(navigator).SingleInstance();

            var thisAssembly = this.GetType().Assembly;

            //navigator.RegisterPage(typeof(MainPage), typeof(ViewModels.MainPageViewModel));
            //navigator.RegisterPage(typeof(PokemonIndex.PokemonIndexPage), typeof(PokemonIndex.PokemonIndexViewModel));

            RegisterPagesWithNavigator(navigator, thisAssembly);

            RegisterViewModels(containerBuilder, thisAssembly);

            containerBuilder.RegisterType<PokemonApi.PokemonService>();

            this.Container = containerBuilder.Build(Autofac.Builder.ContainerBuildOptions.None);

            autoFacFactory.Container = Container;

            var vm = Container.Resolve<Pages.Main.MainPageViewModel>();

            mainPage.BindingContext = vm;

            MainPage = navPage;
        }

        static readonly Type pageType = typeof(Page);

        private void RegisterPagesWithNavigator(NavigationPageNavigator navigator, Assembly assembly)
        {
            var pageTypes = assembly.GetExportedTypes()
                                  .Where(t => pageType.IsAssignableFrom(t))
                                  .Where(t => !t.IsAbstract)
                                  .Select(x => new
                                  {
                                      PageType = x,
                                      ViewModelType = x.GetTypeInfo().GetCustomAttributesData().Where(a => a.AttributeType == typeof(ViewModelAttribute)).SelectMany(a => a.ConstructorArguments).Where(a => a.ArgumentType == typeof(Type)).Select(a => (Type)a.Value).FirstOrDefault()
                                  })
                                  .Where(x => x.ViewModelType != null)
                                  .ToList();


            foreach (var pageType in pageTypes)
            {
                navigator.RegisterPage(pageType.PageType, pageType.ViewModelType);
            }

        }

        static readonly Type viewModelBaseType = typeof(ViewModelBase);

        private void RegisterViewModels(ContainerBuilder containerBuilder, System.Reflection.Assembly assembly)
        {
            var vmTypes = assembly.GetTypes()
                                  ?.Where(t => viewModelBaseType.IsAssignableFrom(t))
                                  ?.Where(t => !t.IsAbstract)
                                  ?.ToList()
                                  ?? new List<Type>();

            foreach (var vmType in vmTypes)
            {
                containerBuilder.RegisterType(vmType);
            }

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
