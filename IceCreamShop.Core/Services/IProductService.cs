using IceCreamShop.Core.Models;

namespace IceCreamShop.Core.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetActiveProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);
        Task<IEnumerable<Product>> GetLowStockProductsAsync();
        Task<bool> UpdateStockAsync(int productId, int newQuantity, string reason, int userId);
        Task<IEnumerable<string>> GetCategoriesAsync();
        Task<IEnumerable<string>> GetFlavorsAsync();
    }
}
