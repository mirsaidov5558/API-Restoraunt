namespace API_Restoran.DTOs.OrderDTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int? UserId { get; set; }
        public decimal TotalSum { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
