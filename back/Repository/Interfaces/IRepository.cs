using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllUsAsync();
        Task<T> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<T> AddAsync(T entity);

    }
}
