using API_Restoran.DTOs.RoleDTOs;

namespace API_Restoran.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task<RoleDto?> GetByIdAsync(int id);
        Task<RoleDto> CreateAsync(CreateRoleDto dto);
        Task<bool> UpdateAsync(int id, CreateRoleDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
