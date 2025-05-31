using API_Restoran.DTOs.OrderItemDTOs;

namespace API_Restoran.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemReadDto>> GetAllAsync();
        Task<OrderItemReadDto?> GetByIdAsync(int id);
        Task<OrderItemReadDto> CreateAsync(OrderItemCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
