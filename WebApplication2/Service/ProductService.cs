using AutoMapper;
using WebApplication2.DTO;
using WebApplication2.Models;
using WebApplication2.Profiles;

namespace WebApplication2.Service
{
    public class ProductService : Profile, IProductService
    {
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
            
           
            
        }

        public ProductService()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

        }

        public Product Map(ProductDTO source)
        {
            return _mapper.Map<Product>(source);
        }

        public ProductDTO Map(Product source)
        {
            return _mapper.Map<ProductDTO>(source);
        }
    }
}
