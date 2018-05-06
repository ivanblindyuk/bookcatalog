using BookCatalog.Skeleton.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using BookCatalog.Skeleton.Core;
using Dapper.Contrib.Extensions;

namespace BookCatalog.Data.Provider
{
    public abstract class DapperRepository<TEntity> : IDapperRepository<TEntity>
        where TEntity : class
    {
        public IDbContext DbContext { get; set; }

        public DapperRepository(IDbContext context)
        {
            DbContext = context;
        }

        public void Delete(int id)
        {
            using(IDbConnection db = new SqlConnection(DbContext.ConnectionString))
            {
                TEntity entity = Get(id);
                db.Delete(entity);
            }
        }
        
        public TEntity Get(int id)
        {
            using (IDbConnection db = new SqlConnection(DbContext.ConnectionString))
            {
                return db.Get<TEntity>(id);
            }
        }

        public int Insert(TEntity entity)
        {
            using (IDbConnection db = new SqlConnection(DbContext.ConnectionString))
            {
                return (int)db.Insert(entity);
            }
        }
        
        public void Update(TEntity entity)
        {
            using (IDbConnection db = new SqlConnection(DbContext.ConnectionString))
            {
                db.Update(entity);
            }
        }
      
        protected void ExecuteSP(string spName)
        {
            using (IDbConnection db = new SqlConnection(DbContext.ConnectionString))
            {
                db.Execute(spName, commandType: CommandType.StoredProcedure);
            }
        }

        protected void Execute(string query)
        {
            using (IDbConnection db = new SqlConnection(DbContext.ConnectionString))
            {
                db.Execute(query);
            }
        }

        protected IEnumerable<T> ExecuteMultiQuery<T>(string query, object param = null)
        {
            using (IDbConnection db = new SqlConnection(DbContext.ConnectionString))
            {
                return db.Query<T>(query, param: param);
            }
        }

        protected T ExecuteSingleQuery<T>(string query)
        {
            using (IDbConnection db = new SqlConnection(DbContext.ConnectionString))
            {
                return db.QueryFirstOrDefault<T>(query);
            }
        }

        protected T ExecuteSingleSP<T>(string spName)
        {
            using (IDbConnection db = new SqlConnection(DbContext.ConnectionString))
            {
                return db.QueryFirstOrDefault<T>(spName, commandType: CommandType.StoredProcedure);
            }
        }

        protected IEnumerable<T> ExecuteMultiSP<T>(string spName)
        {
            using (IDbConnection db = new SqlConnection(DbContext.ConnectionString))
            {
                return db.Query<T>(spName, commandType: CommandType.StoredProcedure);
            }
        }

        public void Dispose()
        {
            
        }

    }
}
