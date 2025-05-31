namespace API_Restoran.DTOs.DishDTOs
{
    public class DishDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Sum { get; set; }
    }
}
