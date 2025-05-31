namespace API_Restoran.Entites
{
    public class DishIngredient
    {
        public int Id { get; set; }   // PK
        public int DishId { get; set; }   // FK → dish.id
        public int IngredientId { get; set; }   // FK → ingredients.id

        public Dish Dish { get; set; } = null!;
        public Ingredient Ingredient { get; set; } = null!;
    }
}
