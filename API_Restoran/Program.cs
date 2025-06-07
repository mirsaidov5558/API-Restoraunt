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
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ITableService, TableService>();


// ✅ CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
                "http://localhost:4200",
                "https://restoran-front-production.up.railway.app"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // ← обязательно, если используешь куки или токены!
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// ✅ Добавляем UseRouting
app.UseRouting();

// ✅ CORS — после UseRouting, до авторизации
app.UseCors("AllowFrontend");

// Авторизация
app.UseAuthorization();

// Маршруты
app.MapControllers();

// Railway порт
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://*:{port}");

// Запуск
app.Run();