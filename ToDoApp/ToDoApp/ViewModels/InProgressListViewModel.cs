using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToDoApp.Domain.Managers;
using ToDoApp.Domain.Models;
using ToDoApp.Extensions;

namespace ToDoApp.ViewModels
{
    public class InProgressListViewModel : ViewModelBase
    {
        private readonly IToDoItemDomainManager _toDoItemDomainManager;

        public ObservableCollection<ToDoItem> ToDoItems { get; set; }
        public ICommand ClickCommand { get; set; }

        public InProgressListViewModel(INavigationService navigationService, IToDoItemDomainManager toDoItemDomainManager)
        : base(navigationService)
        {
            Title = "ToDo";
            _toDoItemDomainManager = toDoItemDomainManager;
            ToDoItems = new ObservableCollection<ToDoItem>();
      
            ClickCommand = new DelegateCommand(NavigateToEditToDoItem);
        }

        public async void LoadItems()
        {
            var items = await _toDoItemDomainManager.GetByStatusAsync(ToDoItemStatus.InProgress);
            ToDoItems.Clear();
            ToDoItems.AddRange(items);
        }

        private async void NavigateToEditToDoItem()
        {
            await NavigationService.NavigateAsync("EditToDoItemPage");
        }
    }
}