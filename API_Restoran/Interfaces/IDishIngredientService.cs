using API_Restoran.DTOs.DishIngredientDTOs;

namespace API_Restoran.Interfaces
{
    public interface IDishIngredientService
    {
        Task<IEnumerable<DishIngredientDto>> GetAllAsync();                 // все связи
        Task<IEnumerable<DishIngredientDto>> GetByDishAsync(int dishId);    // все ингредиенты блюда
        Task<DishIngredientDto?> CreateAsync(CreateDishIngredientDto dto);  // добавить
        Task<bool> DeleteAsync(int id);                                     // удалить по Id
    }
}
