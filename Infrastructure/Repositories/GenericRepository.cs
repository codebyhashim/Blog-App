using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Dapper;
using Domain.Model;
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
                throw new InvalidOperationException("Failed to execute stored procedure in GenericRepository creating post", ex);

            }
           
        }

       

        public async Task<bool> DeleteAsync(int id,string sp)
        {
            try
            {

                var param = new DynamicParameters();
                param.Add("@TagId", id);
                await dbConnection.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);
                return true;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occur while delete post in GenericRepository");
                throw new InvalidOperationException("Failed to execute stored procedure in GenericRepository deleting post", ex);

            }
            }

  

        public async Task<T> GetByIdAsync(int id,string sp)
        {
            try
            {

                var param = new DynamicParameters();
                param.Add("@id", id);
                var post=await dbConnection.QueryFirstOrDefaultAsync<T>(sp, param, commandType: CommandType.StoredProcedure);
             
                return post;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occur while getting post in GenericRepository");
                throw new InvalidOperationException("Failed to execute stored procedure in GenericRepository getting post", ex);

            }
        }

        public async Task<bool> UpdateAsync(T entity,string sp, int id)
        {
            try
            {

                var param = new DynamicParameters(entity);
                param.Add("@Id", id);

                await dbConnection.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);

                return true;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occur while getting post in GenericRepository");
                throw new InvalidOperationException("Failed to execute stored procedure in GenericRepository getting post", ex);

            }
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
