using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Domain.Models;

namespace ToDoApp.Domain.Managers
{
    public interface IToDoItemDomainManager
    {
        Task<IEnumerable<ToDoItem>> GetByStatusAsync(ToDoItemStatus status);

        Task<ToDoItem> GetAsync(int id);

        Task<int> SaveAsync(ToDoItem item);

        Task<int> DeleteAsync(ToDoItem item);

        Task<int> UpdateAllAsync(IEnumerable<ToDoItem> toDoItems);
    }
}