using API_Restoran.Context;
using API_Restoran.DTOs.IngredientDTOs;
using API_Restoran.Entites;
using API_Restoran.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _map;

        public IngredientService(AppDbContext db, IMapper map)
        {
            _db = db;
            _map = map;
        }
        public async Task<IngredientDto> CreateAsync(CreateIngredientDto dto)
        {
            if (await _db.Ingredients.AnyAsync(i => i.Name == dto.Name))
                throw new ArgumentException("Такой ингредиент уже существует");

            var entity = _map.Map<Ingredient>(dto);
            _db.Ingredients.Add(entity);
            await _db.SaveChangesAsync();
            return _map.Map<IngredientDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Ingredients.FindAsync(id);
            if (entity is null) return false;

            _db.Ingredients.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<IngredientDto>> GetAllAsync()
         => _map.Map<IEnumerable<IngredientDto>>(await _db.Ingredients.AsNoTracking().ToListAsync());

        public async Task<IngredientDto?> GetByIdAsync(int id)
        => _map.Map<IngredientDto?>(await _db.Ingredients.FindAsync(id));

        public async Task<IngredientDto?> UpdateAsync(int id, UpdateIngredientDto dto)
        {
            var entity = await _db.Ingredients.FindAsync(id);
            if (entity is null) return null;

            if (dto.Name is { Length: > 0 } && dto.Name != entity.Name)
            {
                if (await _db.Ingredients.AnyAsync(i => i.Name == dto.Name))
                    throw new ArgumentException("Такой ингредиент уже существует");
                entity.Name = dto.Name;
            }

            await _db.SaveChangesAsync();
            return _map.Map<IngredientDto>(entity);
        }
    }
}
