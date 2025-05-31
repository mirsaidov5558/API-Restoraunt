namespace API_Restoran.DTOs.UserDTOs
{
    public class CreateUserDto
    {
        public string Fio { get; set; } = null!;     // ФИО
        public string Login { get; set; } = null!;   // логин
        public string Password { get; set; } = null!;// пароль (plain)
        public int RoleId { get; set; }            // роль
    }
}
