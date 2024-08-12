using ETickets.Data;
using ETickets.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

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

        public T? GetOne(int id)
        {
            return dbSet.Find(id);
        }
    }
}
