using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class ActorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
