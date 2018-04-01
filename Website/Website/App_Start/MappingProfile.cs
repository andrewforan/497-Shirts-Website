using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Website.Dtos;
using Website.Models;

namespace Website.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            CreateMap<Product, ProductDto>();

            //Dto to Doman
            CreateMap<ProductDto, Product>();
        }
    }
}