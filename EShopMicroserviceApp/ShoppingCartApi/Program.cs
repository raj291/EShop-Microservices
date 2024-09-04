using Microsoft.EntityFrameworkCore;
using ShopingCartApi.Core.Contracts.Repository;
using ShopingCartApi.Core.Contracts.Service;
using ShopingCartApi.Core.Entity;
using ShoppingCartApi.Infrastructure.Data;
using ShoppingCartApi.Infrastructure.Repository;
using ShoppingCartApi.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShoppingCartDbContext>(options =>
{
    options.UseSqlServer(Environment.GetEnvironmentVariable("ShoppingCartDb"));
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IPaymentMethodServiceAsync, PaymentMethodServiceAsync>();
builder.Services.AddScoped<IPaymentTypeServiceAsync, PaymentTypeServiceAsync>();
builder.Services.AddScoped<IPaymentMethodRepositoryAsync, PaymentMethodRepositoryAsync>();
builder.Services.AddScoped<IPaymentTypeRepositoryAsync, PaymentTypeRepositoryAsync>();
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