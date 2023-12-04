using Microsoft.EntityFrameworkCore;
using ServiceMarketplaceAPI.Middleware;
using ServiceMarketplaceBLL.Interfaces;
using ServiceMarketplaceBLL.Services;
using ServiceMarketplaceDAL;
using ServiceMarketplaceDAL.Interfaces;
using ServiceMarketplaceDAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
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

app.UseMiddleware<GlobalExceptionMiddleware>();

app.Run();
