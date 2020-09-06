using SQLite;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Persistence.Entities;

namespace ToDoApp.Persistence
{
    public class ToDoAppDatabase: IToDoAppDatabase
    {
        readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });


        public SQLiteAsyncConnection Database => lazyInitializer.Value;
        bool initialized = false;

        public ToDoAppDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ToDo).Name))
                {
                    await Database.CreateTableAsync(typeof(ToDo), CreateFlags.None).ConfigureAwait(false);
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ToDoStatus).Name))
                {
                    await Database.CreateTableAsync(typeof(ToDoStatus), CreateFlags.None).ConfigureAwait(false);
                }
                initialized = true;
            }
        }
    }
}
