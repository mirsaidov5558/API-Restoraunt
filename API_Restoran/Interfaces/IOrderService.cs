using API_Restoran.DTOs.OrderDTOs;

namespace API_Restoran.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<OrderDto?> GetByIdAsync(int id);
        Task<OrderDto> CreateAsync(CreateOrderDto dto);
        Task<OrderDto?> UpdateAsync(int id, UpdateOrderDto dto); // смена статуса
        Task<bool> DeleteAsync(int id);
    }
}
