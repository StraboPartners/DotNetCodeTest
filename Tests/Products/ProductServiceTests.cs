using ApplicationCore.Database;
using ApplicationCore.DataModel;
using ApplicationCore.Services;
using FluentAssertions;

namespace Tests.Products;

public class ProductServiceTests : IDisposable
{
	private readonly Mock<IProductDbAccess> _mockProductDbAccess;
	private readonly IProductService _productService;

	public ProductServiceTests()
	{
		_mockProductDbAccess = new Mock<IProductDbAccess>();
		_productService = new ProductService(_mockProductDbAccess.Object);
	}

	public void Dispose() { }

	[Fact]
	public async Task GetAllProductsAsync_Success()
	{
		List<Product> products = new();
		var numberOfProducts = new Random().Next(3, 10);

		for (int i = 1; i <= numberOfProducts; i++)
		{
			products.Add(new Product
			{
				Id = i,
				ProductNumber = $"Product {i}"
			});
		}

		_mockProductDbAccess.Setup(m => m.GetAllProductsAsync())
			.ReturnsAsync(products);

		var result = await _productService.GetAllProductsAsync();

		result.Should().BeEquivalentTo(products);
		
		_mockProductDbAccess.VerifyAll();
		_mockProductDbAccess.VerifyNoOtherCalls();
	}

	[Theory,InlineData(1),InlineData(13)]
	public async Task GetProductAsync_Mixed(long productId)
	{
		var product = new Product
		{
			Id = 13,
			ProductNumber = "C123",
			Name = "Shelf speaker - 6\"",
			MinimumOrderQuantity = 2
		};
		var products = new List<Product>() { product };

		if (products.Any(product => product.Id == productId))
		{
			_mockProductDbAccess.Setup(m => m.GetProductAsync(productId))
				.ReturnsAsync(products.Single(queryProduct => queryProduct.Id == productId));
		}
		else
		{
			_mockProductDbAccess.Setup(m => m.GetProductAsync(productId))
				.ThrowsAsync(new InvalidOperationException("Sequence contains no elements"));
		}

		var act = () => _productService.GetProductAsync(productId);

		if (productId == 13)
		{
			var result = await act();
			result.Should().BeEquivalentTo(product);
		}
		else
		{
			await act.Should().ThrowAsync<InvalidOperationException>();
		}
		
		_mockProductDbAccess.VerifyAll();
		_mockProductDbAccess.VerifyNoOtherCalls();
	}

	[Fact]
	public async Task CreateProductAsync_Success()
	{
		var input = new Product
		{
			Id = default,
			ProductNumber = "Creation test"
		};
		var output = input with { Id = 789 };

		_mockProductDbAccess.Setup(m => m.CreateProductAsync(input))
			.ReturnsAsync(output);

		var result = await _productService.CreateProductAsync(input);

		result.Should().BeEquivalentTo(output);
		
		_mockProductDbAccess.VerifyAll();
		_mockProductDbAccess.VerifyNoOtherCalls();
	}

	[Fact]
	public async Task UpdateProductAsync_Success()
	{
		var product = new Product
		{
			Id = 842,
			ProductNumber = "Update test"
		};

		_mockProductDbAccess.Setup(m => m.UpdateProductAsync(product))
			.ReturnsAsync(product);

		var result = await _productService.UpdateProductAsync(product);

		result.Should().BeEquivalentTo(product);
		
		_mockProductDbAccess.VerifyAll();
		_mockProductDbAccess.VerifyNoOtherCalls();
	}

	[Fact]
	public async Task DeleteProductsAsync_Success()
	{
		var productIds = new HashSet<long>() { 4484, 452, 6, 563323 };

		_mockProductDbAccess.Setup(m => m.DeleteProductsAsync(productIds))
			.ReturnsAsync(productIds.Count);

		var result = await _productService.DeleteProductsAsync(productIds);

		result.Should().Be(productIds.Count);
		
		_mockProductDbAccess.VerifyAll();
		_mockProductDbAccess.VerifyNoOtherCalls();
	}
}