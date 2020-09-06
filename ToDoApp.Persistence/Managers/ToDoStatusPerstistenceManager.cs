using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Persistence.Entities;

namespace ToDoApp.Persistence.Managers
{
    public class ToDoStatusPerstistenceManager : IToDoStatusPersistenceManager
    {
        private readonly SQLiteAsyncConnection _database;

        public ToDoStatusPerstistenceManager(IToDoAppDatabase database)
        {
            _database = database.Database;
        }

        public async Task<int> DeleteAsync(ToDoStatus entity)
        {
            return await _database.DeleteAsync(entity);
        }

        public async Task<List<ToDoStatus>> GetAllAsync()
        {
            return await _database.Table<ToDoStatus>().ToListAsync();
        }

        public async Task<ToDoStatus> GetAsync(int id)
        {
            return await _database.Table<ToDoStatus>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> SaveAsync(ToDoStatus entity)
        {
            return entity.Id != 0 ? await _database.UpdateAsync(entity) : await _database.InsertAsync(entity);
        }
    }
}
