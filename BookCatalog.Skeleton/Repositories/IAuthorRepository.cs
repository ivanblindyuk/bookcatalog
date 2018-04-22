using BookCatalog.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Skeleton.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
    }
}
