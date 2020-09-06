using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Persistence.Managers
{
    public interface IBasePersistenceManger<T>
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetAsync(int id);

        Task<int> SaveAsync(T entity);

        Task<int> DeleteAsync(T entity);
    }
}