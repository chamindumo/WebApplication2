using WebApplication2.Models;

namespace WebApplication2.Service
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProducByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(int id, Product product);
        Task DeleteProductAsync(int id);
    }

}
