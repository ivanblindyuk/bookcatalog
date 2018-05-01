using BookCatalog.Skeleton.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Resolution.Core
{
    public class DbContext : IDbContext
    {
        public string ConnectionString { get; set; }
    }
}
