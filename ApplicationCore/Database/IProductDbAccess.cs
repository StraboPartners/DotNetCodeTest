using ApplicationCore.DataModel;

namespace ApplicationCore.Database;

public interface IProductDbAccess
{
    Task<List<Product>> GetAllProductsAsync();
    Task<Product> GetProductAsync(long productId);
    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task<int> DeleteProductsAsync(HashSet<long> productIds);
}
