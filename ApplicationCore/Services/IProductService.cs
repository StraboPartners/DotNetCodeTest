using ApplicationCore.DataModel;

namespace ApplicationCore.Services;

public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync();
    Task<Product> GetProductAsync(long productId);
    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task<int> DeleteProductsAsync(HashSet<long> productIds);
}
