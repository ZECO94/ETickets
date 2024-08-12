using ETickets.Data;
using ETickets.Models;
using ETickets.Repository.IRepository;

namespace ETickets.Repository
{
    public class CinemaRepository : Repository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
