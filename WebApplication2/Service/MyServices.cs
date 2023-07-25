using AutoMapper;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public class MyServices
    {
        private readonly AutoMapper.IMapper _mapper;

        public MyServices(AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
        }


        public Books GetBooks(Books books)
        {
            return _mapper.Map<Books>(books);
        }

        public Product GetProductViewModel(Product product)
        {
            return _mapper.Map<Product>(product);
        }

    }
}