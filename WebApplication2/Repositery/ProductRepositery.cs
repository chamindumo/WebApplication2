using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repositery
{

    public class ProductRepositery: IProductRepositery
        {
            private readonly DataContext _context;

            public ProductRepositery(DataContext context)
            {
                _context = context;
            }

            public  async Task AddProductAsync(Product product)
            {
                _context.Product.Add(product);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteProductAsync(int id)
            {
                var product = await _context.Product.FindAsync(id);
                if (product == null)
                    return;

                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }

            public async Task<List<Product>> GetAllProductsAsync()
            {
                return await _context.Product.ToListAsync();
            }

            public async Task<Product> GetProducByIdAsync(int id)
            {
                return await _context.Product.FindAsync(id);
            }

            public async Task UpdateProductAsync(int id, Product product)
            {
                var existingproduct = await _context.Product.FindAsync(id);
                if (existingproduct == null)
                    return;

                existingproduct.Id = product.Id;
                existingproduct.Names = product.Names;
                existingproduct.Descriptions = product.Descriptions;

                await _context.SaveChangesAsync();
            }
        }
    
}
