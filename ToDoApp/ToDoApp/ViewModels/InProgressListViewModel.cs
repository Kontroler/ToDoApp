using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.ViewModels
{
    public class InProgressListViewModel : ViewModelBase
    {
        public InProgressListViewModel(INavigationService navigationService)
        : base(navigationService)
        {   
            Title = "ToDo";
        }
    }
}
