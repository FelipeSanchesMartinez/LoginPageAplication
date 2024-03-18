namespace Auth.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public List<UserRole>? Roles { get; set; }

    }
}
