using API_Restoran.DTOs.TableDTOs;

namespace API_Restoran.Interfaces
{
    public interface ITableService
    {
        Task<IEnumerable<TableDto>> GetAllAsync();
        Task<TableDto?> GetByIdAsync(int id);
        Task<TableDto> CreateAsync(CreateTableDto dto);
        Task<bool> UpdateAsync(int id, CreateTableDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
