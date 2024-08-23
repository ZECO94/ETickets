using ETickets.Models;
using ETickets.Repository;
using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace ETickets.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CinemaController : Controller
    {
        private readonly ICinemaRepository cinemaRepository;
        private readonly IMovieRepository movieRepository;
        public CinemaController(ICinemaRepository cinemaRepository,
            IMovieRepository movieRepository)
        {
            this.cinemaRepository = cinemaRepository;
            this.movieRepository = movieRepository;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var result = cinemaRepository.GetAll();
            return View(result);
        }
        [AllowAnonymous]
        public IActionResult AllMovies(int id)
        {
            var result = movieRepository.Get(x => x.CinemaId == id, x => x.Category
            , x => x.Cinema);
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                cinemaRepository.Create(cinema);
                cinemaRepository.Commit();
                return RedirectToAction("Index");
            }
            return View(cinema);
        }
        public IActionResult Edit(int id)
        {
            var result = cinemaRepository.Get(x => x.Id == id).FirstOrDefault();
            return result != null ? View(result) : RedirectToAction("NotFound", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cinema cinema)
        {
            cinemaRepository.Edit(cinema);
            cinemaRepository.Commit();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result = cinemaRepository.Get(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                cinemaRepository.Delete(result);
                cinemaRepository.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }
    }
}
