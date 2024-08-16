using ETickets.Data;
using ETickets.Models;
using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly ApplicationDbContext context1;
        
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
            this.context1 = context;
        }
        public async Task<IEnumerable<Movie>> SearchByNameAsync(string name)
        {
            return await context1.Movies
                .Where(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }





    }
}
