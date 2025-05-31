using System.ComponentModel.DataAnnotations;
using System.Data;

namespace API_Restoran.Entites
{
    public class User
    {
        public int Id { get; set; }    // PK, соответствует SERIAL id
        public string Fio { get; set; } = null!;   // ФИО пользователя
        public string Login { get; set; } = null!; // Логин (уникален
        public string PasswordHash { get; set; } = null!; // Хэш пароля

        public int RoleId { get; set; }            // FK → role.id
        public Role Role { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
