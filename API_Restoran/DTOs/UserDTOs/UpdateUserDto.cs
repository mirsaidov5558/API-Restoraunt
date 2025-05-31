namespace API_Restoran.DTOs.UserDTOs
{
    public class UpdateUserDto
    {
        public string? Fio { get; set; }             // ФИО (nullable — необязательно)
        public string? Password { get; set; }        // новый пароль
        public int? RoleId { get; set; }          // новая роль
    }
}
