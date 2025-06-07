using API_Restoran.Context;
using API_Restoran.DTOs.RoleDTOs;
using API_Restoran.Entites;
using API_Restoran.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RoleService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public async Task<RoleDto?> GetByIdAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            return role == null ? null : _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> CreateAsync(CreateRoleDto dto)
        {
            var role = _mapper.Map<Role>(dto);
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<bool> UpdateAsync(int id, CreateRoleDto dto)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;

            role.Name = dto.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
