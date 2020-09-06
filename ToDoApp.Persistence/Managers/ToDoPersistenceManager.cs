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
            return await _database.Table<ToDo>().FirstOrDefaultAsync(toDo => toDo.Id == id);
        }

        public async Task<List<ToDo>> GetByStatusAsync(string statusName)
        {
            var toDoList = await _database.Table<ToDo>().Where(toDo => toDo.Status.Name == statusName).ToListAsync();
            return toDoList;
        }

        public async Task<int> SaveAsync(ToDo entity)
        {
            var status = _database.Table<ToDoStatus>().FirstOrDefaultAsync(x => x.Name == entity.Status.Name);
            if (status == null)
            {
                await _database.InsertAsync(entity.Status);
            }
            else
            {
                entity.Status.Id = status.Id;
            }
            return entity.Id != 0 ? await _database.UpdateAsync(entity) : await _database.InsertAsync(entity);
        }
    }
}