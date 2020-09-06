using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Persistence.Entities;

namespace ToDoApp.Persistence.Managers
{
    public interface IToDoPersistenceManager : IBasePersistenceManger<ToDo>
    {
        Task<List<ToDo>> GetByStatusAsync(string statusName);
    }
}