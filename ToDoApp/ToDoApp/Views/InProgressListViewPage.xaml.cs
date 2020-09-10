using ToDoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InProgressListViewPage : ContentPage
    {
        private InProgressListViewModel ViewModel { get; set; }
        public InProgressListViewPage()
        {
            InitializeComponent();
            ViewModel = BindingContext as InProgressListViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.LoadItems();
        }
    }
}