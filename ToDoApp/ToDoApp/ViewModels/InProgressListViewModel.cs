using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using ToDoApp.Domain.Managers;
using ToDoApp.Domain.Models;
using ToDoApp.Extensions;
using Xamarin.Forms.Internals;

namespace ToDoApp.ViewModels
{
    public class InProgressListViewModel : ViewModelBase
    {
        private readonly IToDoItemDomainManager _toDoItemDomainManager;

        public ObservableCollection<ToDoItem> ToDoItems { get; set; }

        public InProgressListViewModel(INavigationService navigationService, IToDoItemDomainManager toDoItemDomainManager)
        : base(navigationService)
        {
            Title = "ToDo";
            _toDoItemDomainManager = toDoItemDomainManager;
            ToDoItems = new ObservableCollection<ToDoItem>();

            LoadItems();
        }

        private async void LoadItems()
        {
            var items = await _toDoItemDomainManager.GetByStatusAsync(ToDoItemStatus.InProgress);
            ToDoItems.AddRange(items);            
        }
    }
}