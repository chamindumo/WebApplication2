using WebApplication2.DTO;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public interface IProductService
    {
        Product Map(ProductDTO source);
        ProductDTO Map(Product source);
    }
}
