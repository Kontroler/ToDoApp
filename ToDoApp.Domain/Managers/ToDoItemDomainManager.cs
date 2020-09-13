using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Domain.Models;
using ToDoApp.Persistence.Entities;
using ToDoApp.Persistence.Managers;

namespace ToDoApp.Domain.Managers
{
    public class ToDoItemDomainManager : IToDoItemDomainManager
    {
        private readonly IToDoPersistenceManager _toDoPeristenceManager;
        private readonly IMapper _mapper;

        public ToDoItemDomainManager(IToDoPersistenceManager toDoPeristenceManager, IMapper mapper)
        {
            _toDoPeristenceManager = toDoPeristenceManager;
            _mapper = mapper;
        }

        public async Task<int> DeleteAsync(ToDoItem item)
        {
            var toDoEntity = _mapper.Map<ToDo>(item);
            return await _toDoPeristenceManager.DeleteAsync(toDoEntity);
        }

        public async Task<IEnumerable<ToDoItem>> GetByStatusAsync(ToDoItemStatus status)
        {
            var toDoList = await _toDoPeristenceManager.GetByStatusAsync(status.ToString());
            var toDoItems = toDoList.Select(toDo => _mapper.Map<ToDoItem>(toDo));
            return toDoItems;
        }

        public async Task<ToDoItem> GetAsync(int id)
        {
            var toDo = await _toDoPeristenceManager.GetAsync(id);
            var toDoItem = _mapper.Map<ToDoItem>(toDo);
            return toDoItem;
        }

        public async Task<int> SaveAsync(ToDoItem item)
        {
            var toDo = _mapper.Map<ToDo>(item);
            return await _toDoPeristenceManager.SaveAsync(toDo);
        }

        public async Task<int> UpdateAllAsync(IEnumerable<ToDoItem> toDoItems)
        {
            var toDoList = toDoItems.Select(toDo => _mapper.Map<ToDo>(toDo)).ToList();
            return await _toDoPeristenceManager.UpdateAllAsync(toDoList);
        }
    }
}