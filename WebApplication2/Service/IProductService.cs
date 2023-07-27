using WebApplication2.DTO;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public interface IProductService
    {
        void Create(ProductDTO productDTO);
        void Update(int id, ProductDTO productDTO);

    }
}
