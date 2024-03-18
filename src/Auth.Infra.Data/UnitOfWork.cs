using Auth.Domain.Interfaces;

namespace Auth.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext _sqlContext;
        public UnitOfWork(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
        public bool SaveChanges()
        {
            return _sqlContext.SaveChanges() > 0;
        }
    }
}
