using ToDoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompletedListViewPage : ContentPage
    {
        private CompletedListViewModel ViewModel { get; set; }

        public CompletedListViewPage()
        {
            InitializeComponent();
            ViewModel = BindingContext as CompletedListViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.LoadItems();
        }
    }
}