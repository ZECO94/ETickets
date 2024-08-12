using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class CinemaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
