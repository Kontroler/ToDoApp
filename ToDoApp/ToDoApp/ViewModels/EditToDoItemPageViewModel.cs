using Prism.Commands;
using Prism.Navigation;
using System;
using System.Windows.Input;
using ToDoApp.Domain.Managers;
using ToDoApp.Domain.Models;

namespace ToDoApp.ViewModels
{
    public class EditToDoItemPageViewModel : ViewModelBase
    {
        private readonly IToDoItemDomainManager _toDoItemDomainManager;
        public string ToDoItemDescription { get; set; }
        public ICommand SaveCommand { get; set; }

        public EditToDoItemPageViewModel(INavigationService navigationService, IToDoItemDomainManager toDoItemDomainManager)
        : base(navigationService)
        {
            Title = "Edit ToDo";
            _toDoItemDomainManager = toDoItemDomainManager;
            SaveCommand = new DelegateCommand(SaveToDoItem);
        }

        private async void SaveToDoItem()
        {
            var toDoItem = new ToDoItem
            {
                Description = ToDoItemDescription,
                Date = DateTime.Now,
                Status = ToDoItemStatus.InProgress
            };
            await _toDoItemDomainManager.SaveAsync(toDoItem);
            await NavigationService.GoBackAsync();
        }
    }
}