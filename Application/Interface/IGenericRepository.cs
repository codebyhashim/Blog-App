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

        Task<T> GetByIdAsync(int id,string sp);

        Task<bool> UpdateAsync(T entity,string sp,int id);

        Task<bool> DeleteAsync(int id,string sp);

        Task<IEnumerable<T>> GetAllAsync();


    }
}
