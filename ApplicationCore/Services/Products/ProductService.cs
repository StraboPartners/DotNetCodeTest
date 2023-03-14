using ApplicationCore.Database;
using ApplicationCore.DataModel;

namespace ApplicationCore.Services;

public class ProductService : IProductService
{
    private readonly IProductDbAccess _productDbAccess;
    public ProductService(IProductDbAccess productDbAccess)
	{
		_productDbAccess = productDbAccess;
	}

	public Task<List<Product>> GetAllProductsAsync() 
		=> _productDbAccess.GetAllProductsAsync();

    public Task<Product> GetProductAsync(long productId) 
		=> _productDbAccess.GetProductAsync(productId);

    public Task<Product> CreateProductAsync(Product product) 
		=> _productDbAccess.CreateProductAsync(product);

    public Task<Product> UpdateProductAsync(Product product) 
		=> _productDbAccess.UpdateProductAsync(product);

    public Task<int> DeleteProductsAsync(HashSet<long> productIds) 
        => _productDbAccess.DeleteProductsAsync(productIds);
}
