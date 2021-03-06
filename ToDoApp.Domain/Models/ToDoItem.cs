﻿using System;

namespace ToDoApp.Domain.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public ToDoItemStatus Status { get; set; }
    }
}