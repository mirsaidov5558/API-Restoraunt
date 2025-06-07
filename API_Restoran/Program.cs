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

// Add services to the container.
// Настройка CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // ← адрес Angular-приложения
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/* ---------- Swagger всегда, если хотим проверять prod ---------- */
app.UseSwagger();
app.UseSwaggerUI();

// Использование политики CORS (должно быть до авторизации!)
app.UseCors("AllowFrontend");

/* ---------- HTTPS (Railway сам терминирует TLS) ---------- */
if (!app.Environment.IsDevelopment())
{
    
    // app.UseHttpsRedirection();
}

/* ---------- Пробрасываем порт Railway ---------- */
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://*:{port}");

app.UseAuthorization();
app.MapControllers();
app.Run();