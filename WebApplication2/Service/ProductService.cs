using AutoMapper;
using java.awt.print;
using WebApplication2.Data;
using WebApplication2.DTO;
using WebApplication2.Models;
using WebApplication2.Profiles;
using WebApplication2.Repositery;

namespace WebApplication2.Service
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ProductRepositery _productRepository;
        private readonly DataContext _context;

        public ProductService(IMapper mapper, ProductRepositery productRepository, DataContext context)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _context = context;
        }

        public async Task Create(ProductDTO productDTO)
        {
            var product = _mapper.Map<ProductDTO, Product>(productDTO);
           
           _productRepository.AddProductAsync(product);
        }

        public async Task Update(int id, ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
         


            _productRepository.UpdateProductAsync(id, product);

        }
    }
}
