using API_Restoran.DTOs.UserDTOs;

namespace API_Restoran.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();            // список всех
        Task<UserDto?> GetByIdAsync(int id);                 // поиск по Id
        Task<UserDto> CreateAsync(CreateUserDto dto);        // создание
        Task<UserDto?> UpdateAsync(int id, UpdateUserDto dto); // обновление
        Task<bool> DeleteAsync(int id);                      // удаление
    }
}
