using API_Restoran.Context;
using API_Restoran.DTOs.OrderDTOs;
using API_Restoran.Entites;
using API_Restoran.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _map;

        public OrderService(AppDbContext db, IMapper map)
        {
            _db = db;
            _map = map;
        }
        public async Task<OrderDto> CreateAsync(CreateOrderDto dto)
        {
            var entity = _map.Map<Order>(dto);
            entity.CreatedAt = DateTime.UtcNow;
            entity.TotalSum = 0;               // при создании позиций ещё нет

            _db.Orders.Add(entity);
            await _db.SaveChangesAsync();

            // пересчитаем сумму (на случай, если OrderItems уже добавлены скриптом/триггером)
            await RecalculateTotal(entity.Id);

            return _map.Map<OrderDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
         => _map.Map<IEnumerable<OrderDto>>(
               await _db.Orders
                        .Include(o => o.Table)
                        .Include(o => o.Status)
                        .Include(o => o.User)
                        .AsNoTracking()
                        .ToListAsync());

        public async Task<OrderDto?> GetByIdAsync(int id)
         => _map.Map<OrderDto?>(
               await _db.Orders
                        .Include(o => o.Table)
                        .Include(o => o.Status)
                        .Include(o => o.User)
                        .FirstOrDefaultAsync(o => o.Id == id));

        public async Task<OrderDto?> UpdateAsync(int id, UpdateOrderDto dto)
        {
            var entity = await _db.Orders.FindAsync(id);
            if (entity is null) return null;

            // Смена статуса (без логирования)
            if (dto.StatusId.HasValue && dto.StatusId != entity.StatusId)
            {
                entity.StatusId = dto.StatusId.Value;
            }

            // Опциональная смена столика
            if (dto.TableId.HasValue)
            {
                entity.TableId = dto.TableId.Value;
            }

            // Опциональная смена официанта
            if (dto.UserId.HasValue)
            {
                entity.UserId = dto.UserId.Value;
            }

            await _db.SaveChangesAsync();

            // Пересчёт суммы
            await RecalculateTotal(entity.Id);

            return _map.Map<OrderDto>(entity);
        }

        private async Task RecalculateTotal(int orderId)
        {
            var sum = await _db.OrderItems
                               .Where(oi => oi.OrderId == orderId)
                               .SumAsync(oi => oi.Price * oi.Count);

            var order = await _db.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.TotalSum = sum;
                await _db.SaveChangesAsync();
            }
        }
    }
}
