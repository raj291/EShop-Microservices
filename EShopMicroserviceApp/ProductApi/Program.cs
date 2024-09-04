using Microsoft.EntityFrameworkCore;
using ProductApi.Core.Contracts.Repository;
using ProductApi.Core.Contracts.Services;
using ProductApi.Infrastructure.Data;
using ProductApi.Infrastructure.Repository;
using ProductApi.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDbcontext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDb"));
    options.UseSqlServer(Environment.GetEnvironmentVariable("ProductDb"));
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IProductCategoryServiceAsync, ProductCategoryServiceAsync>();
builder.Services.AddScoped<IProductCategoryRepositoryAsync, ProductCategoryRepositoryAsync>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();