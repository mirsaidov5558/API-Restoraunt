using API_Restoran.Context;
using API_Restoran.DTOs.UserDTOs;
using API_Restoran.Entites;
using API_Restoran.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;   // контекст БД
        private readonly IMapper _mapper;    // AutoMapper

        public UserService(AppDbContext db, IMapper mapper) // конструктор DI
        {
            _db = db;                       // сохраняем контекст
            _mapper = mapper;               // сохраняем маппер
        }
        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            // проверяем уникальность логина
            if (await _db.Users.AnyAsync(u => u.Login == dto.Login))
                throw new ArgumentException("Login already exists"); // бросаем ошибку

            var user = new User                               // новый объект
            {
                Fio = dto.Fio,                                // копируем ФИО
                Login = dto.Login,                            // копируем логин
                PasswordHash = BCrypt.Net.BCrypt              // хэшируем пароль
                              .HashPassword(dto.Password),
                RoleId = dto.RoleId                           // роль
            };

            _db.Users.Add(user);                              // добавляем в контекст
            await _db.SaveChangesAsync();                     // сохраняем

            return _mapper.Map<UserDto>(user);                // возвращаем DTO
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _db.Users.FindAsync(id);         // ищем
            if (user is null) return false;                   // нет — false

            _db.Users.Remove(user);                           // удаляем
            await _db.SaveChangesAsync();                     // сохраняем
            return true;                                      // успех
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _db.Users
                .Include(u => u.Role)       // подгружаем роль
                .ToListAsync();             // выполняем запрос
            return _mapper.Map<IEnumerable<UserDto>>(users); // маппим в DTO
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _db.Users
                .Include(u => u.Role)       // роль
                .FirstOrDefaultAsync(u => u.Id == id); // поиск
            return _mapper.Map<UserDto?>(user);        // маппим
        }

        public async Task<UserDto?> UpdateAsync(int id, UpdateUserDto dto)
        {
            var user = await _db.Users.FindAsync(id);         // ищем по Id
            if (user is null) return null;                    // если нет — null

            if (dto.Fio is not null) user.Fio = dto.Fio;      // обновляем ФИО
            if (dto.Password is not null)                     // если пришёл пароль
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password); // перехэш

            if (dto.RoleId.HasValue) user.RoleId = dto.RoleId.Value; // роль

            await _db.SaveChangesAsync();                     // сохраняем изменения
            await _db.Entry(user).Reference(u => u.Role).LoadAsync(); // подгружаем роль

            return _mapper.Map<UserDto>(user);                // маппим DTO
        }
    }
}
