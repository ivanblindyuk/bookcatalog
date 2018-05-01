using BookCatalog.Resolution.Mapping;
using BookCatalog.Skeleton.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Resolution.Core
{
    public class Mapper : IMapper
    {
        AutoMapper.IMapper _mapper;

        public Mapper()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            InitializeAutoMapper();
        }

        private void InitializeAutoMapper()
        {
            AutoMapper.MapperConfiguration config = new AutoMapper.MapperConfiguration(cfg =>
                new Maps().Create(cfg)
            );

            _mapper = new AutoMapper.Mapper(config);
        }

        public TOut Map<TIn, TOut>(TIn source)
        {
            return _mapper.Map<TIn, TOut>(source);
        }
    }
}
