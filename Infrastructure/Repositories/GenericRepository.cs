using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Dapper;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDbConnection dbConnection;
        private readonly ILogger logger;

        public GenericRepository(IDbConnection dbConnection, ILogger<GenericRepository<T>> logger)
        {
            this.dbConnection = dbConnection;
            this.logger = logger;
        }

        public async Task<bool> AddAsync( string sp, object parameter)
        {
            try
            {

                var param = new DynamicParameters(parameter);
              await dbConnection.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);
                return true;

            }
            catch (Exception ex)
            {
                logger.LogError(ex,"error occur while create post in GenericRepository");
                throw;
            }
           
        }

       

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
