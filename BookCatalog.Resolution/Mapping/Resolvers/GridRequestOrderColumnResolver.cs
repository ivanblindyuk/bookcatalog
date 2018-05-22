using AutoMapper;
using BookCatalog.Data.Model.Grid;
using BookCatalog.View.Model.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Resolution.Mapping.Resolvers
{
    class GridRequestOrderColumnResolver : IValueResolver<RequestVM, RequestEM, int?>
    {
        public int? Resolve(RequestVM source, RequestEM destination, int? destMember, ResolutionContext context)
        {
            if (source.order == null || source.order.Length == 0 || string.IsNullOrEmpty(source.order[0].dir))
                return null;

            return source.order[0].column;
        }
    }
}
