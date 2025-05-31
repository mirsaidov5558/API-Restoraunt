using API_Restoran.Context;
using API_Restoran.Interfaces;
using API_Restoran.Profiles;
using API_Restoran.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(UserProfile)); // ищет все профили


builder.Services.AddScoped<IUserService, UserService>(); // UserService
builder.Services.AddScoped<IIngredientService, IngredientService>(); // IngredientService
builder.Services.AddScoped<IDishService, DishService>(); // DishService
builder.Services.AddScoped<IDishIngredientService, DishIngredientService>(); // DishIngredientService
builder.Services.AddScoped<IOrderService, OrderService>(); // OrderService
builder.Services.AddScoped<IMenuService, MenuService>(); // MenuService
builder.Services.AddScoped<IMenuKitchenService, MenuKitchenService>(); // MenuKitchenService
builder.Services.AddScoped<IOrderItemService, OrderItemService>(); // OrderItemService


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
