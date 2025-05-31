using API_Restoran.Context;
using API_Restoran.DTOs.MenuDTOs;
using API_Restoran.Entites;
using API_Restoran.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Services
{
    public class MenuService : IMenuService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _map;

        public MenuService(AppDbContext db, IMapper map)
        {
            _db = db;
            _map = map;
        }

        public async Task<IEnumerable<MenuDto>> GetAllAsync()
            => _map.Map<IEnumerable<MenuDto>>(await _db.Menus.AsNoTracking().ToListAsync());

        public async Task<MenuDto?> GetByIdAsync(int id)
        {
            var entity = await _db.Menus.FindAsync(id);
            return entity is null ? null : _map.Map<MenuDto>(entity);
        }

        public async Task<MenuDto> CreateAsync(CreateMenuDto dto)
        {
            var entity = _map.Map<Menu>(dto);
            entity.OpenedAt = DateTime.UtcNow;

            _db.Menus.Add(entity);
            await _db.SaveChangesAsync();

            return _map.Map<MenuDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Menus.FindAsync(id);
            if (entity is null) return false;

            _db.Menus.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
