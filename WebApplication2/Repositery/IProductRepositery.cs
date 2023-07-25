using WebApplication2.Models;

namespace WebApplication2.Repositery
{
    public interface IProductRepositery
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProducByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(int id, Product product);
        Task DeleteProductAsync(int id);
    }

}
