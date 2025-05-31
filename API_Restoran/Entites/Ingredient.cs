namespace API_Restoran.Entites
{
    public class Ingredient
    {
        public int Id { get; set; }          // PK
        public string Name { get; set; } = null!;
        // Связь многие-ко-многим с Dish через промежуточную сущность DishIngredient
        public ICollection<DishIngredient> DishIngredients { get; set; } = new List<DishIngredient>();
    }
}

