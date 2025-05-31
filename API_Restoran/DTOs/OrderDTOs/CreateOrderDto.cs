namespace API_Restoran.DTOs.OrderDTOs
{
    public class CreateOrderDto
    {
        public int TableId { get; set; }
        public int? UserId { get; set; }
        public int StatusId { get; set; }
    }
}
