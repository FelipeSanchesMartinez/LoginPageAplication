namespace Auth.Domain.Entities
{
    public class UserRole : Entity
    {
        public string Name { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
