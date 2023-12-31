﻿using AutoMapper;
using WebApplication2.DTO;
using WebApplication2.Models;

namespace WebApplication2.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
        }

    }
}
