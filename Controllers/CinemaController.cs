using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace ETickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaRepository cinemaRepository;
        public CinemaController(ICinemaRepository cinemaRepository)
        {
            this.cinemaRepository = cinemaRepository;
        }

        public IActionResult Index()
        {
            var result = cinemaRepository.GetAll();
            return View(result);
        }
    }
}
