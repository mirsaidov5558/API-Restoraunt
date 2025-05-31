using API_Restoran.DTOs.DishDTOs;

namespace API_Restoran.Interfaces
{
    public interface IDishService
    {
        Task<IEnumerable<DishDto>> GetAllAsync();
        Task<DishDto?> GetByIdAsync(int id);
        Task<DishDto> CreateAsync(CreateDishDto dto);
        Task<DishDto?> UpdateAsync(int id, UpdateDishDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
