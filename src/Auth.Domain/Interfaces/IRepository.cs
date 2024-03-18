using Auth.Domain.Entities;
using System.Linq.Expressions;

namespace Auth.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        void Delete(long id);
        List<T> GetAll(int page, int limit);
        T? GetById(long id);
        void Insert(T entity);
        List<T> Search(Expression<Func<T, bool>> expression, int page, int limit);
        void Update(T entity);
    }
}