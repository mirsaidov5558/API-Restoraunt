namespace API_Restoran.Entites
{
    public class Dish
    {
        public int Id { get; set; }          // PK
        public string Name { get; set; } = null!;  // Название, уникальное
        public decimal Sum { get; set; }    // Цена (sum) >= 0

        // Связь многие-ко-многим с Ingredient через DishIngredient
        public ICollection<DishIngredient> DishIngredients { get; set; } = new List<DishIngredient>();

        // Связь один-ко-многим с OrderItem (позиции заказов)
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
