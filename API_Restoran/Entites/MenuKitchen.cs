namespace API_Restoran.Entites
{
    public class MenuKitchen
    {
        public int Id { get; set; }

        // Foreign key на заказ (уникальный)
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;  // Навигация на заказ

        public DateTime SentAt { get; set; }
    }
}
