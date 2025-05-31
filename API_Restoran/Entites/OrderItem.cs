namespace API_Restoran.Entites
{
    public class OrderItem
    {
        public int Id { get; set; }

        // Foreign key на заказ
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;  // Навигация на заказ

        // Foreign key на блюдо
        public int DishId { get; set; }
        public Dish Dish { get; set; } = null!;  // Навигация на блюдо

        public int Count { get; set; }  // Количество
        public decimal Price { get; set; }  // Цена за штуку
    }
}
