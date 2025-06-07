using API_Restoran.Context;
using API_Restoran.DTOs.TableDTOs;
using API_Restoran.Entites;
using API_Restoran.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Services
{
    public class TableService : ITableService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TableService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TableDto>> GetAllAsync()
        {
            var tables = await _context.Tables.ToListAsync();
            return _mapper.Map<IEnumerable<TableDto>>(tables);
        }

        public async Task<TableDto?> GetByIdAsync(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            return table == null ? null : _mapper.Map<TableDto>(table);
        }

        public async Task<TableDto> CreateAsync(CreateTableDto dto)
        {
            var table = _mapper.Map<Table>(dto);
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
            return _mapper.Map<TableDto>(table);
        }

        public async Task<bool> UpdateAsync(int id, CreateTableDto dto)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return false;

            table.Name = dto.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return false;

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
