namespace API_Restoran.Entites
{
    public class Order
    {
        public int Id { get; set; }

        public int? TableId { get; set; }
        public Table? Table { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public decimal TotalSum { get; set; }

        public int? StatusId { get; set; }  // внешний ключ
        public Status? Status { get; set; }  // навигационное свойство

        public DateTime CreatedAt { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }

        public MenuKitchen? MenuKitchen { get; set; }
    }
}
