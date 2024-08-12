namespace ETickets.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        void Edit(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T? GetOne(int id);
        void Commit();
    }
}
