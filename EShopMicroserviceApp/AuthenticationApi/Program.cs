using System.Text;
using Authentication.Core.Contracts.Repository;
using Authentication.Core.Contracts.Service;
using Authentication.Core.Entity;
using Authentication.Infrastructure;
using Authentication.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.SaveToken = true;
    option.RequireHttpsMetadata = false;
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    }; 
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AuthenticationDbContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("AuthenticationDb")));
    options.UseSqlServer(Environment.GetEnvironmentVariable("AuthenticationDb"));
});
builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<AuthenticationDbContext>();
builder.Services.AddScoped<IAccountRepositoryAsync, AccountRepositoryAsync>();
builder.Services.AddScoped<IAccountServiceAsync, AccountServiceAsync>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();