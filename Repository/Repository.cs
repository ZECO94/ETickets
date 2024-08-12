using ETickets.Data;
using ETickets.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ETickets.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> dbSet;
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        
        public void Commit()
        {
            context.SaveChanges();
        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
            Commit();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            Commit();
        }

        public void Edit(T entity)
        {
            dbSet.Update(entity);
            Commit();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T , bool>> expression , string includeproperty = null)
        {
            if(includeproperty != null)
                return dbSet.Include(includeproperty).Where(expression);
            else
                return dbSet.Where(expression);
        }
    }
}
