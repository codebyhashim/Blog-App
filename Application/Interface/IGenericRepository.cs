using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public  interface IGenericRepository<T> where T : class
    {
        Task<bool> AddAsync(string sp,object parameter);

        Task<T> GetByIdAsync(int id);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();


    }
}
