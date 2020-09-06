using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Domain.Models
{
    public class ToDoItemStatus
    {
        public int Id { get; set; }
        public StatusName Name { get; set; }

        public enum StatusName
        {
            InProgress, Done
        }
    }
}
