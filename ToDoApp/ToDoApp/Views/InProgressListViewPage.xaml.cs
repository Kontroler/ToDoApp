using Plugin.InputKit.Shared.Controls;
using System;
using ToDoApp.Domain.Models;
using ToDoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CheckBox = Plugin.InputKit.Shared.Controls.CheckBox;

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

        private void CheckboxCheckChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            var toDoItem = (ToDoItem)checkbox.CommandParameter;
            //checkbox.IsChecked = !checkbox.IsChecked;
            ViewModel.ChangeStatus(toDoItem, checkbox.IsChecked);
        }
    }
}