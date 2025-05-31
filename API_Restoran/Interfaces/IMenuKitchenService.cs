using API_Restoran.DTOs.MenuKitchenDTOs;

namespace API_Restoran.Interfaces
{
    public interface IMenuKitchenService
    {
        Task<IEnumerable<MenuKitchenDto>> GetAllAsync();
        Task<MenuKitchenDto?> GetByOrderAsync(int orderId);      // по OrderId
        Task<MenuKitchenDto> CreateAsync(CreateMenuKitchenDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
