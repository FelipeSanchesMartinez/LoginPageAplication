using Auth.Domain.Entities;
using Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SqlContext context) : base(context)
        {
        }

        public User? GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(x => x.Name == email);
        }
    }
}
