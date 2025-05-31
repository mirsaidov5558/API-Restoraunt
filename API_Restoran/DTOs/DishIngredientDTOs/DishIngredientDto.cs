namespace API_Restoran.DTOs.DishIngredientDTOs
{
    public class DishIngredientDto
    {
        public int Id { get; set; }   // PK
        public string DishName { get; set; }      // Название блюда
        public string IngredientName { get; set; } // Название ингредиента
    }
}
