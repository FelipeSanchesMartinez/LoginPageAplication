using Auth.Domain.Entities;
using Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Auth.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly SqlContext Context;
        protected DbSet<T> DbSet;

        public Repository(SqlContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }


        public virtual List<T> GetAll(int page, int limit)
        {
            return DbSet
                .AsNoTracking()
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToList();
        }


        public virtual T? GetById(long id)
        {
            return DbSet
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public virtual void Insert(T entity) { entity.CreateAt = DateTime.Now; DbSet.Add(entity); }
        public virtual void Update(T entity)
        {
            entity.CreateAt = DateTime.Now;
            DbSet.Update(entity);
        }

        public virtual void Delete(long id)
        {
            var entity = GetById(id);
            DbSet.Remove(entity);
        }


        public List<T> Search(Expression<Func<T, bool>> expression, int page, int limit)
        {
            return DbSet
                  .AsNoTracking()
                 .Where(expression)
                 .Skip((page - 1) * limit)
                 .Take(limit)
                 .ToList();
        }


    }
}
