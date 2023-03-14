using ApplicationCore.Database;
using ApplicationCore.DataModel;

namespace ApplicationCore.Services;

public class ProductService : IProductService
{
    IProductDbAccess _productDbAccess;

    public Task<Product> CreateProductAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteProductsAsync(HashSet<long> productIds)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductAsync(long productId)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateProductAsync(Product product)
    {
        throw new NotImplementedException();
    }
}
