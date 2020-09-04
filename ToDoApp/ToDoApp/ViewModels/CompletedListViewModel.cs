using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.ViewModels
{
    public class CompletedListViewModel : ViewModelBase
    {
        public CompletedListViewModel(INavigationService navigationService)
        : base(navigationService)
        {
            Title = "ToDo";
        }
    }
}
