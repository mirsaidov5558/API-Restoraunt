using API_Restoran.DTOs.IngredientDTOs;

namespace API_Restoran.Interfaces
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientDto>> GetAllAsync();
        Task<IngredientDto?> GetByIdAsync(int id);
        Task<IngredientDto> CreateAsync(CreateIngredientDto dto);
        Task<IngredientDto?> UpdateAsync(int id, UpdateIngredientDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
