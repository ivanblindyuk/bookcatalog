using AutoMapper;
using BookCatalog.Data.Model;
using BookCatalog.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Resolution.Mapping
{
    class Maps
    {
        public void Create(IMapperConfigurationExpression config)
        {
            config.CreateMap<Author, AuthorVM>()
                .ReverseMap();

            config.CreateMap<Book, BookVM>()
                .ReverseMap();
        }
    }
}
