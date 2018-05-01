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

namespace BookCatalog.Data.Provider
{
    public abstract class DapperRepository<TEntity> : IDapperRepository<TEntity>
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
                db.Execute($"Delete from {TableName} where Id = @Id", new { Id = id });
            }
        }

        public void Execute(string query)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(string query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> QueryMany<T>(string query)
        {
            using(IDbConnection db = new SqlConnection(DbContext.ConnectionString))
            {
                return db.Query<T>(query);
            }
        }

        private string TableName
        {
            get
            {
                Type entityType = typeof(TEntity);
                TableAttribute tableAttr = entityType.GetCustomAttribute<TableAttribute>();

                if (tableAttr == null)
                    throw new Exception("Entity wasn't recognized as table entity");
                else if (string.IsNullOrEmpty(tableAttr.Name))
                    throw new Exception("Table name is not specified");
                else
                    return tableAttr.Name;
            }
        }

    }
}
