namespace API_Restoran.Entites
{
    public class Role
    {
        public int Id { get; set; }         // PK

        public string Name { get; set; } = null!;   // admin, waiter, cook …

        public ICollection<User> Users { get; set; } = new List<User>(); // связь 1:M
    }
}
