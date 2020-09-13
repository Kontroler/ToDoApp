using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using ToDoApp.Domain.Managers;
using ToDoApp.Domain.Models;
using ToDoApp.Extensions;

namespace ToDoApp.ViewModels
{
    public class CompletedListViewModel : ViewModelBase
    {
        private readonly IToDoItemDomainManager _toDoItemDomainManager;

        public ObservableCollection<ToDoItem> ToDoItems { get; set; }

        public CompletedListViewModel(INavigationService navigationService, IToDoItemDomainManager toDoItemDomainManager)
        : base(navigationService)
        {
            Title = "Completed";
            _toDoItemDomainManager = toDoItemDomainManager;
            ToDoItems = new ObservableCollection<ToDoItem>();
        }

        public async void LoadItems()
        {
            var items = (await _toDoItemDomainManager.GetByStatusAsync(ToDoItemStatus.Done)).OrderByDescending(item => item.Date);
            ToDoItems.Clear();
            ToDoItems.AddRange(items);
        }
    }
}