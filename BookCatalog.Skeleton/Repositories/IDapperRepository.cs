using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Skeleton.Repositories
{
    public interface IDapperRepository<TEntity>
    {
        TEntity Get(int id);
        int Insert(TEntity entity);
        void Delete(int id);
        void Execute(string query);
        T Query<T>(string query);
        IEnumerable<T> QueryMany<T>(string query);
    }
}
