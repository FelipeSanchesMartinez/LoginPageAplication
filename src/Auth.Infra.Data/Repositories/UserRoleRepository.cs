using Auth.Domain.Entities;
using Auth.Domain.Interfaces;

namespace Auth.Infra.Data.Repositories
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(SqlContext context) : base(context)
        {
        }
    }
}
