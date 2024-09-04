using CustomerApi.Core.Contracts.Repository;
using CustomerApi.Core.Contracts.Services;
using CustomerApi.Infrastructure.Data;
using CustomerApi.Infrastructure.Repository;
using CustomerApi.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

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
var customerDb = Environment.GetEnvironmentVariable("CustomerDb");
Console.WriteLine($"CustomerDb: {customerDb}");
//builder.Services.AddDbContext<CustomerDbContext>();
builder.Services.AddDbContext<CustomerDbContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDb"));
    options.UseSqlServer(Environment.GetEnvironmentVariable("CustomerDb"));
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>();
builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();

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