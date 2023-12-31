﻿using AutoMapper;
using WebApplication2.Data;
using WebApplication2.DTO;
using WebApplication2.Models;
using WebApplication2.Repositery;

namespace WebApplication2.Service
{
    public class ProductService1 : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepositery _productRepository;
        private readonly DataContext _context;


        public ProductService1(IMapper mapper, IProductRepositery productRepository, DataContext context)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _context = context;
        }
        public void Create(ProductDTO productDTO)
        {
            var product = _mapper.Map<ProductDTO, Product>(productDTO);

            _productRepository.AddProductAsync(product);
        }

        public void Update(int id, ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            _productRepository.UpdateProductAsync(id, product);
        }
    }
}
