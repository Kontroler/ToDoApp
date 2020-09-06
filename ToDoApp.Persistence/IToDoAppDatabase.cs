using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Persistence
{
    public interface IToDoAppDatabase
    {
        SQLiteAsyncConnection Database { get; }
    }
}
