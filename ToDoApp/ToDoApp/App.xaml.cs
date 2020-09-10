using Prism;
using Prism.Ioc;
using ToDoApp.ViewModels;
using ToDoApp.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Prism.DryIoc;
using ToDoApp.Domain;

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

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<InProgressListViewPage, InProgressListViewModel>();

            containerRegistry.GetContainer().AddDomain();
            containerRegistry.RegisterForNavigation<EditToDoItemPage, EditToDoItemPageViewModel>();
        }
    }
}
