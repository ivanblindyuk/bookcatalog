using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookCatalog.View.Model.DataTable;
using BookCatalog.Data.Model.Grid;

namespace BookCatalog.Resolution.Mapping.Resolvers
{
    class GridRequestOrderDirectionResolver : IValueResolver<RequestVM, RequestEM, bool?>
    {
        public bool? Resolve(RequestVM source, RequestEM destination, bool? destMember, ResolutionContext context)
        {
            if (source.order == null || source.order.Length == 0 || string.IsNullOrEmpty(source.order[0].dir))
                return null;

            switch (source.order[0].dir)
            {
                case "desc": return true;
                default: return false;
            }
        }
    }
}
