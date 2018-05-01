using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Skeleton.Core
{
    public interface IDbContext
    {
        string ConnectionString { get; set; }
    }
}
