using Auth.Domain.Entities;

namespace Auth.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {

        public User? GetByEmail(string email);
    }
}
