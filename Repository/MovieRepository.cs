using ETickets.Data;
using ETickets.Models;
using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        
        
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
            
        }
        





    }
}
