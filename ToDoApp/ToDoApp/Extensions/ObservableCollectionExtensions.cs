using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms.Internals;

namespace ToDoApp.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> o, IEnumerable<T> items)
        {
            items.ForEach(item => o.Add(item));
        }
    }
}
