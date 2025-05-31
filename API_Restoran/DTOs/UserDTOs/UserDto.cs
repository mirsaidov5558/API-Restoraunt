namespace API_Restoran.DTOs.UserDTOs
{
    public class UserDto
    {
        public int Id { get; set; }         // идентификатор
        public string Fio { get; set; } = null!;   // ФИО
        public string Login { get; set; } = null!; // логин
        public string Role { get; set; } = null!;  // строка роли
    }
}
