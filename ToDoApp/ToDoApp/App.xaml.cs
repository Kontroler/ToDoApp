using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using ToDoApp.Domain;
using ToDoApp.ViewModels;
using ToDoApp.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace ToDoApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.GetContainer().AddDomain();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<InProgressListViewPage, InProgressListViewModel>();
            containerRegistry.RegisterForNavigation<CompletedListViewPage, CompletedListViewModel>();
            containerRegistry.RegisterForNavigation<EditToDoItemPage, EditToDoItemPageViewModel>();
        }
    }
}