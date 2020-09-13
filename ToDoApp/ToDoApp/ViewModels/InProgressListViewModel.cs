using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        public ICommand AddItemCommand { get; set; }
        public ICommand CompleteCommand { get; set; }

        public InProgressListViewModel(INavigationService navigationService, IToDoItemDomainManager toDoItemDomainManager)
        : base(navigationService)
        {
            Title = "ToDo";
            _toDoItemDomainManager = toDoItemDomainManager;
            ToDoItems = new ObservableCollection<ToDoItem>();

            AddItemCommand = new DelegateCommand(NavigateToEditToDoItem);
            CompleteCommand = new DelegateCommand(Complete);
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

        public void ChangeStatus(ToDoItem toDoItem, bool isCheckd)
        {
            if (toDoItem == null) return;
            toDoItem.Status = isCheckd ? ToDoItemStatus.Done : ToDoItemStatus.InProgress;
        }

        private async void Complete()
        {            
            await _toDoItemDomainManager.UpdateAllAsync(ToDoItems.AsEnumerable());
            LoadItems();
        }
    }
}