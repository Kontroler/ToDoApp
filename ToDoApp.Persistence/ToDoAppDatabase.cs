using SQLite;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Persistence.Entities;

namespace ToDoApp.Persistence
{
    public class ToDoAppDatabase : IToDoAppDatabase
    {
        private readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
          {
              return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
          });

        public SQLiteAsyncConnection Database => lazyInitializer.Value;
        private bool initialized = false;

        public ToDoAppDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        private async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ToDo).Name))
                {
                    Database.CreateTableAsync<ToDo>().Wait();
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ToDoStatus).Name))
                {
                    Database.CreateTableAsync<ToDoStatus>().Wait();
                    //await Database.CreateTableAsync(typeof(ToDoStatus), CreateFlags.None).ConfigureAwait(false);
                }
                initialized = true;
            }
        }
    }
}