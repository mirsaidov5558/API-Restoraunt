using API_Restoran.Context;
using API_Restoran.DTOs.OrderItemDTOs;
using API_Restoran.Entites;
using API_Restoran.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrderItemService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderItemReadDto>> GetAllAsync()
        {
            var items = await _context.OrderItems.ToListAsync();
            return _mapper.Map<IEnumerable<OrderItemReadDto>>(items);
        }

        public async Task<OrderItemReadDto?> GetByIdAsync(int id)
        {
            var item = await _context.OrderItems.FindAsync(id);
            return item == null ? null : _mapper.Map<OrderItemReadDto>(item);
        }

        public async Task<OrderItemReadDto> CreateAsync(OrderItemCreateDto dto)
        {
            var entity = _mapper.Map<OrderItem>(dto);
            _context.OrderItems.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderItemReadDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.OrderItems.FindAsync(id);
            if (item == null) return false;

            _context.OrderItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
