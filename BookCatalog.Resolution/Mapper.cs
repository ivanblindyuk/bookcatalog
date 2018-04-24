using BookCatalog.Resolution.Mapping;
using BookCatalog.Skeleton.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Resolution
{
    public class Mapper : IMapper
    {
        static Mapper _instance;
        public static Mapper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Mapper();

                return _instance;
            }
        }

        AutoMapper.IMapper _mapper;

        private Mapper()
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
