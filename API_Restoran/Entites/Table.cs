namespace API_Restoran.Entites
{
    public class Table
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Связь один-ко-многим с заказами
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        // Связь один-ко-многим с меню
        public ICollection<Menu> Menus { get; set; } = new List<Menu>();
    }
}
