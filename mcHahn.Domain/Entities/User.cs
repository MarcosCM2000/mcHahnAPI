namespace mcHahn.Domain.Entities
{
    public class User
    {
        public int Id { get; set; } = new Random().Next(1,100);
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
