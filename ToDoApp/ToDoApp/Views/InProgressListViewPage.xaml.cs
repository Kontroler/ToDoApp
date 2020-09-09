using ToDoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InProgressListViewPage : ContentPage
    {
        public InProgressListViewPage()
        {
            InitializeComponent();            
        }
    }
}