using AutoMapper;
using BookCatalog.Data.Model;
using BookCatalog.Data.Model.Grid;
using BookCatalog.View.Model;
using BookCatalog.View.Model.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using BookCatalog.Resolution.Mapping.Resolvers;

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

            CreateGridMaps(config);
        }

        private void CreateGridMaps(IMapperConfigurationExpression config)
        {
            config.CreateMap<RequestVM, RequestEM>()
                .ForMember(d => d.Offset, opt => opt.MapFrom(src => src.start))
                .ForMember(d => d.Length, opt => opt.MapFrom(src => src.length))
                .ForMember(d => d.OrderBy, opt => opt.ResolveUsing<GridRequestOrderColumnResolver>())
                .ForMember(d => d.IsDescending, opt => opt.ResolveUsing<GridRequestOrderDirectionResolver>())
                .ForMember(d => d.SearchExpression, opt => opt.MapFrom(src => src.search.value));

            config.CreateMap<Authors, AuthorsVM>();
            config.CreateMap<Books, BooksVM>();
        }
    }
}
