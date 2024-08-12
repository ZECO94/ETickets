using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;
        public MovieController (IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public IActionResult Index()
        {
            //movieRepository
            return View();
        }
    }
}
