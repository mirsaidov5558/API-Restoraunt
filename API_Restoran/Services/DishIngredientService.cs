using API_Restoran.Context;
using API_Restoran.DTOs.DishIngredientDTOs;
using API_Restoran.Entites;
using API_Restoran.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Services
{
    public class DishIngredientService : IDishIngredientService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _map;

        public DishIngredientService(AppDbContext db, IMapper map)
        {
            _db = db;
            _map = map;
        }

        /* ---------- СОЗДАНИЕ ---------- */
        public async Task<DishIngredientDto?> CreateAsync(CreateDishIngredientDto dto)
        {
            if (await _db.DishIngredients.AnyAsync(di => di.DishId == dto.DishId &&
                                                          di.IngredientId == dto.IngredientId))
                throw new ArgumentException("Ингредиент уже добавлен в блюдо");

            var entity = _map.Map<DishIngredient>(dto);
            _db.DishIngredients.Add(entity);
            await _db.SaveChangesAsync();

            return await MapWithNames(entity.Id);
        }

        /* ---------- УДАЛЕНИЕ ---------- */
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.DishIngredients.FindAsync(id);
            if (entity is null) return false;

            _db.DishIngredients.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        /* ---------- ВСЕ СВЯЗИ ---------- */
        public async Task<IEnumerable<DishIngredientDto>> GetAllAsync()
        {
            return await _db.DishIngredients
                .Include(di => di.Dish)
                .Include(di => di.Ingredient)
                .Select(di => new DishIngredientDto
                {
                    Id = di.Id,
                    DishName = di.Dish.Name,
                    IngredientName = di.Ingredient.Name
                })
                .AsNoTracking()
                .ToListAsync();
        }

        /* ---------- СВЯЗИ ДЛЯ КОНКРЕТНОГО БЛЮДА ---------- */
        public async Task<IEnumerable<DishIngredientDto>> GetByDishAsync(int dishId)
        {
            return await _db.DishIngredients
                .Where(di => di.DishId == dishId)
                .Include(di => di.Dish)
                .Include(di => di.Ingredient)
                .Select(di => new DishIngredientDto
                {
                    Id = di.Id,
                    DishName = di.Dish.Name,
                    IngredientName = di.Ingredient.Name
                })
                .AsNoTracking()
                .ToListAsync();
        }

        /* ---------- ВСПОМОГАТЕЛЬНЫЙ МЕТОД ---------- */
        private async Task<DishIngredientDto> MapWithNames(int id)
        {
            return await _db.DishIngredients
                .Include(di => di.Dish)
                .Include(di => di.Ingredient)
                .Where(di => di.Id == id)
                .Select(di => new DishIngredientDto
                {
                    Id = di.Id,
                    DishName = di.Dish.Name,
                    IngredientName = di.Ingredient.Name
                })
                .SingleAsync();
        }
    }
}
