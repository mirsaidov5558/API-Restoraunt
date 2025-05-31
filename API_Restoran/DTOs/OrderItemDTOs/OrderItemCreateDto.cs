namespace API_Restoran.DTOs.OrderItemDTOs
{
    public class OrderItemCreateDto
    {
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
