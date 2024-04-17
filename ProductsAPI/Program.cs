using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Database;
using ProductsAPI.Endpoints;
using ProductsAPI.Services;
using ProductsAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<ProductDbContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("ProductsDB")));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();
app.MapProducts();
app.Run();