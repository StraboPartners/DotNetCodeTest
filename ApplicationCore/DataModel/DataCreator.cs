using ApplicationCore.Database;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.DataModel;

public static class DataCreator
{
	public static void SeedData(StraboContext context)
	{
		// Create EA, CS units of measure
		context.UnitsOfMeasure.Add(new UnitOfMeasure
		{
			Name = "EA",
			Description = "Each",
			ExternalId = "ea"
		});
		context.UnitsOfMeasure.Add(new UnitOfMeasure
		{
			Name = "CS",
			Description = "Case",
			ExternalId = "cs"
		});
		
		// Create example products
		context.Products.Add(new Product
		{
			ProductNumber = "A0001",
			Name = "HDMI cables - 6ft",
			UnitOfMeasureName = "EA"
		});
		context.Products.Add(new Product
		{
			ProductNumber = "A0002",
			Name = "HDMI cables - 12ft",
			UnitOfMeasureName = "EA",
			MinimumOrderQuantity = 2
		});
		context.Products.Add(new Product
		{
			ProductNumber = "A0003",
			Name = "HDMI cables - 6ft pack",
			UnitOfMeasureName = "CS"
		});

		context.PriceTypes.Add(new PriceType
		{
			Name = "MSRP",
			Description = "Manufacturer suggested retail price",
			ExternalId = "MSRP"
		});

		context.SaveChanges();

		var a0001Id = context.Products.Single(product => product.ProductNumber == "A0001").Id;
		var a0002Id = context.Products.Single(product => product.ProductNumber == "A0002").Id;

		context.Prices.Add(new Price
		{
			ProductId = a0001Id,
			PriceTypeName = "MSRP",
			Amount = (decimal)7.30,
			UnitOfMeasureName = "EA"
		});
		context.Prices.Add(new Price
		{
			ProductId = a0002Id,
			PriceTypeName = "MSRP",
			Amount = (decimal)12.30,
			UnitOfMeasureName = "EA",
			QuantityFrom = 1,
			QuantityTo = 5
		});
		context.Prices.Add(new Price
		{
			ProductId = a0002Id,
			PriceTypeName = "MSRP",
			Amount = (decimal)11.55,
			UnitOfMeasureName = "EA",
			QuantityFrom = 6
		});
		var firstDayOfMonth = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, 1);
		context.Prices.Add(new Price
		{
			ProductId = a0002Id,
			PriceTypeName = "MSRP",
			Amount = (decimal)9.99,
			UnitOfMeasureName = "EA",
			QuantityFrom = 10,
			FromDate = firstDayOfMonth,
			ToDate = firstDayOfMonth.AddMonths(1).AddDays(-1)
		});

		context.SaveChanges();
	}
}