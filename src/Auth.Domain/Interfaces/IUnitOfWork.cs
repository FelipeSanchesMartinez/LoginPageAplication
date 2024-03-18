namespace Auth.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        bool SaveChanges();
    }
}