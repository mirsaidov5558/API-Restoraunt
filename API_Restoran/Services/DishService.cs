using API_Restoran.Context;
using API_Restoran.DTOs.DishDTOs;
using API_Restoran.Entites;
using API_Restoran.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Services
{
    public class DishService : IDishService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _map;

        public DishService(AppDbContext db, IMapper map)
        {
            _db = db;
            _map = map;
        }

        public async Task<DishDto> CreateAsync(CreateDishDto dto)
        {
            if (await _db.Dishes.AnyAsync(d => d.Name == dto.Name))
                throw new ArgumentException("Такое блюдо уже существует");

            var entity = _map.Map<Dish>(dto);
            _db.Dishes.Add(entity);
            await _db.SaveChangesAsync();
            return _map.Map<DishDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Dishes.FindAsync(id);
            if (entity is null) return false;

            _db.Dishes.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DishDto>> GetAllAsync()
          => _map.Map<IEnumerable<DishDto>>(await _db.Dishes.AsNoTracking().ToListAsync());

        public async Task<DishDto?> GetByIdAsync(int id)
         => _map.Map<DishDto?>(await _db.Dishes.FindAsync(id));


        public async Task<DishDto?> UpdateAsync(int id, UpdateDishDto dto)
        {
            var entity = await _db.Dishes.FindAsync(id);
            if (entity is null) return null;

            if (!string.IsNullOrWhiteSpace(dto.Name) && dto.Name != entity.Name)
            {
                if (await _db.Dishes.AnyAsync(d => d.Name == dto.Name))
                    throw new ArgumentException("Такое блюдо уже существует");
                entity.Name = dto.Name;
            }

            if (dto.Sum is not null && dto.Sum >= 0)
                entity.Sum = dto.Sum.Value;

            await _db.SaveChangesAsync();
            return _map.Map<DishDto>(entity);
        }
    }
}
