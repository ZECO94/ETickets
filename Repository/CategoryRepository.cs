using ETickets.Data;
using ETickets.Models;
using ETickets.Repository.IRepository;

namespace ETickets.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
