namespace Auth.Domain.Entities
{
    public abstract  class Entity
    {
        public long Id { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
