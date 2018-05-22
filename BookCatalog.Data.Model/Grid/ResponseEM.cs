using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Data.Model.Grid
{
    public class ResponseEM<TEntity> where TEntity : class
    {
        public int Total { get; set; }
        public IEnumerable<TEntity> Rows { get; set; }
    }
}
