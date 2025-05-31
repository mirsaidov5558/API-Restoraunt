using API_Restoran.Context;
using API_Restoran.DTOs.MenuKitchenDTOs;
using API_Restoran.Entites;
using API_Restoran.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Services
{
    public class MenuKitchenService : IMenuKitchenService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _map;

        public MenuKitchenService(AppDbContext db, IMapper map)
        {
            _db = db;
            _map = map;
        }
        public async Task<IEnumerable<MenuKitchenDto>> GetAllAsync()
            => _map.Map<IEnumerable<MenuKitchenDto>>(await _db.MenuKitchens.AsNoTracking().ToListAsync());

        public async Task<MenuKitchenDto?> GetByOrderAsync(int orderId)
        {
            var entity = await _db.MenuKitchens.FirstOrDefaultAsync(mk => mk.OrderId == orderId);
            return entity is null ? null : _map.Map<MenuKitchenDto>(entity);
        }

        public async Task<MenuKitchenDto> CreateAsync(CreateMenuKitchenDto dto)
        {
            if (await _db.MenuKitchens.AnyAsync(mk => mk.OrderId == dto.OrderId))
                throw new ArgumentException("Для этого заказа запись уже существует");

            var entity = _map.Map<MenuKitchen>(dto);
            entity.SentAt = DateTime.UtcNow;

            _db.MenuKitchens.Add(entity);
            await _db.SaveChangesAsync();

            return _map.Map<MenuKitchenDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.MenuKitchens.FindAsync(id);
            if (entity is null) return false;

            _db.MenuKitchens.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
