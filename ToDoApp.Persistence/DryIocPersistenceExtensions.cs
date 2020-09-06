using DryIoc;
using SQLite;
using ToDoApp.Persistence.Managers;

namespace ToDoApp.Persistence
{
    public static class DryIocPersistenceExtensions
    {
        public static void AddPersistence(this IContainer c)
        {
            c.Register<IToDoAppDatabase, ToDoAppDatabase>();
            c.Register<IToDoPersistenceManager, ToDoPersistenceManager>();
            c.Register<IToDoStatusPersistenceManager, ToDoStatusPerstistenceManager>();
        }
    }
}
