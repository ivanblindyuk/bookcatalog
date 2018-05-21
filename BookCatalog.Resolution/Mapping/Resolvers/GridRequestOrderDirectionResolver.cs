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
            if (source.sorting == null || string.IsNullOrEmpty(source.sorting.direction))
                return null;

            switch (source.sorting.direction)
            {
                case "descending": return true;
                default: return false;
            }
        }
    }
}
