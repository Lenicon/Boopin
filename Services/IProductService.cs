using Boopin.Models;

namespace Boopin.Services;

public interface IProductService
{
    Task<IReadOnlyList<Product>> GetAllAsync();
    Task<IReadOnlyList<Product>> GetFeaturedAsync();
    Task<IReadOnlyList<Product>> GetByCategoryAsync(ProductCategory? category);
    Task<Product?> GetByIdAsync(int id);
}
