namespace API_Restoran.DTOs.DishIngredientDTOs
{
    public class CreateDishIngredientDto
    {
        public int DishId { get; set; }   // Блюдо
        public int IngredientId { get; set; }   // Ингредиент
    }
}
