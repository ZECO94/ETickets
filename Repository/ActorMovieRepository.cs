using ETickets.Data;
using ETickets.Models;
using ETickets.Repository.IRepository;

namespace ETickets.Repository
{
    public class ActorMovieRepository : Repository<ActorMovies>,
        IActorMovieRepository
    {
        public ActorMovieRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
