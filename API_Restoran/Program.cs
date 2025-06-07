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


// Настройка CORS — политика "AllowAll" разрешает любые источники, заголовки и методы (для разработки)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Включаем Swagger для генерации и отображения документации
app.UseSwagger();
app.UseSwaggerUI();

// Включаем маршрутизацию (обязательно перед CORS)
app.UseRouting();

// Включаем CORS с выбранной политикой — после UseRouting, до UseAuthorization
app.UseCors("AllowAll");

// Включаем авторизацию (если в проекте используется)
app.UseAuthorization();

// Подключаем маршруты контроллеров
app.MapControllers();

// Настраиваем порт из переменной окружения (Railway, Heroku и др.), если не задан — 8080
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://*:{port}");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); // это применит все миграции при старте
}
// Запускаем приложение
app.Run();