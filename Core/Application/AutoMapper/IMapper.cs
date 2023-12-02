using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Real_Estate.Core.Application.Dto;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.AutoMapper
{
    public class IMapper
    {
        public static Mapper Automapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                    cfg.CreateMap<Location, LocationDto>();
                    cfg.CreateMap<Manager, ManagerDto>();
                    cfg.CreateMap<Product, ProductDto>();
                    cfg.CreateMap<User, UserDto>();

            });
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}