using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Persistence.Entities;

namespace ToDoApp.Persistence.Managers
{
    public class ToDoPersistenceManager : IToDoPersistenceManager
    {
        private readonly SQLiteAsyncConnection _database;

        public ToDoPersistenceManager(IToDoAppDatabase database)
        {
            _database = database.Database;
        }

        public async Task<int> DeleteAsync(ToDo entity)
        {
            return await _database.DeleteAsync(entity);
        }

        public async Task<List<ToDo>> GetAllAsync()
        {
            return await _database.Table<ToDo>().ToListAsync();
        }

        public async Task<ToDo> GetAsync(int id)
        {
            return await _database.Table<ToDo>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> SaveAsync(ToDo entity)
        {
            return entity.Id != 0 ? await _database.UpdateAsync(entity) : await _database.InsertAsync(entity);
        }
    }
}
