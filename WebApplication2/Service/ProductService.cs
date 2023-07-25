using AutoMapper;
using java.awt.print;
using WebApplication2.DTO;
using WebApplication2.Models;
using WebApplication2.Profiles;
using WebApplication2.Repositery;

namespace WebApplication2.Service
{
    public class ProductService : Profile, IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepositery _productRepository;


        public ProductService()
        {


            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

        }

        public void Create(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productRepository.AddProductAsync(product);
        }

        public void Update(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            int id = product.Id;
            _productRepository.UpdateProductAsync(id, product);

        }
    }
}
