using ApplicationCore.Database;
using ApplicationCore.DataModel;
using ApplicationCore.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

builder.Services.AddPooledDbContextFactory<StraboContext>(options =>
{
	options.UseNpgsql("Host=localhost;Database=strabocodetest;Username=strabo;Password=strabo")
		.EnableDetailedErrors()
		.EnableSensitiveDataLogging();
});

builder.Services.TryAddScoped<IProductService, ProductService>();
builder.Services.TryAddScoped<IProductDbAccess, ProductDbAccess>();
builder.Services.TryAddScoped<IPriceService, PriceService>();
builder.Services.TryAddScoped<IPriceDbAccess, PriceDbAccess>();
builder.Services.TryAddScoped<IUnitOfMeasureService, UnitOfMeasureService>();
builder.Services.TryAddScoped<IUnitOfMeasureDbAccess, UnitOfMeasureDbAccess>();
builder.Services.AddValidatorsFromAssembly(typeof(ProductValidator).Assembly);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

var dbContextFactory = app.Services.CreateScope().ServiceProvider.GetRequiredService<IDbContextFactory<StraboContext>>();
using var context = dbContextFactory.CreateDbContext();
if (context.Database.GetPendingMigrations().Any())
{
	context.Database.Migrate();
	DataCreator.SeedData(context);
}

app.Run();
