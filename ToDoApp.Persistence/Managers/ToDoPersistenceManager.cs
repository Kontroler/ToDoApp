using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
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
            return await _database.GetAllWithChildrenAsync<ToDo>(todo => true, true);
        }

        public async Task<ToDo> GetAsync(int id)
        {
            return await _database.Table<ToDo>().FirstOrDefaultAsync(toDo => toDo.Id == id);
        }

        public async Task<List<ToDo>> GetByStatusAsync(string statusName)
        {
            var status = await _database.Table<ToDoStatus>().FirstOrDefaultAsync(x => x.Name == statusName);
            if (status != null)
            {
                var toDoList = await _database.GetAllWithChildrenAsync<ToDo>(toDo => toDo.StatusId == status.Id, true);
                return toDoList;
            }
            return new List<ToDo>();
        }

        public async Task<int> SaveAsync(ToDo entity)
        {
            var status = await _database.Table<ToDoStatus>().FirstOrDefaultAsync(x => x.Name == entity.Status.Name);
            if (status == null)
            {
                await _database.InsertAsync(entity.Status);
            }
            else
            {
                entity.StatusId = status.Id;
                entity.Status.Id = status.Id;
            }
            return entity.Id != 0 ? await _database.UpdateAsync(entity) : await _database.InsertAsync(entity);
        }
    }
}