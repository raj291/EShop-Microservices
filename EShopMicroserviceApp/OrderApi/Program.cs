using Microsoft.EntityFrameworkCore;
using OrderApi.Core.Contracts.Repository;
using OrderApi.Core.Contracts.Services;
using OrderApi.Infrastructure.Data;
using OrderApi.Infrastructure.Repository;
using OrderApi.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
builder.Services.AddDbContext<OrderDbContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("OrderDb"));
    options.UseSqlServer(Environment.GetEnvironmentVariable("OrderDb"));
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();
builder.Services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
builder.Services.AddScoped<IOrderDetailsServiceAsync, OrderDetailServiceAsync>();
builder.Services.AddScoped<IOrderDetailsRepositoryAsync, OrderDetailRepositoryAsync>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.UseCors();
app.MapControllers();

app.Run();