namespace API_Restoran.DTOs.MenuDTOs
{
    public class MenuDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int StatusId { get; set; }
        public DateTime OpenedAt { get; set; }
    }
}
