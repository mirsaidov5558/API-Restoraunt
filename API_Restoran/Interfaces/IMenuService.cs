using API_Restoran.DTOs.MenuDTOs;

namespace API_Restoran.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuDto>> GetAllAsync();
        Task<MenuDto?> GetByIdAsync(int id);
        Task<MenuDto> CreateAsync(CreateMenuDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
