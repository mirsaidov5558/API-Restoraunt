namespace API_Restoran.Entites
{
    public class Menu
    {
        public int Id { get; set; }

        // Foreign key на стол
        public int TableId { get; set; }
        public Table Table { get; set; } = null!;  // Навигация на стол

        // Foreign key на статус
        public int StatusId { get; set; }
        public Status Status { get; set; } = null!;  // Навигация на статус

        public DateTime OpenedAt { get; set; }
    }
}
