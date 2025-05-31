using API_Restoran.Configurations;
using API_Restoran.Entites;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet‑ы
        public DbSet<User> Users => Set<User>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();
        public DbSet<Dish> Dishes => Set<Dish>();
        public DbSet<DishIngredient> DishIngredients => Set<DishIngredient>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Menu> Menus => Set<Menu>();
        public DbSet<MenuKitchen> MenuKitchens => Set<MenuKitchen>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Status> Statuses => Set<Status>();
        public DbSet<Table> Tables => Set<Table>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1️⃣  Схема по умолчанию — "cafe"
            modelBuilder.HasDefaultSchema("cafe");

            // 2️⃣  Подключаем ВСЕ конфигурации из сборки
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
