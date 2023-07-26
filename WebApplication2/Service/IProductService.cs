using WebApplication2.DTO;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public interface IProductService
    {
        Task Create(ProductDTO productDTO);
        Task Update(int id, ProductDTO productDTO);

    }
}
