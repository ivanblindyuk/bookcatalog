using BookCatalog.Skeleton.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Skeleton.Repositories
{
    public interface IDapperRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IDbContext DbContext { get; set; }

        TEntity Get(int id);
        int Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
