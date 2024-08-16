using ETickets.Models;
using ETickets.Repository;
using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var result = movieRepository.GetAll(x=>x.Category , x=>x.Cinema);
            return View(result);
        }
        //public IActionResult Details(int id)
        //{
        //    var result1 = movieRepository.Get(x => x.Id == id).FirstOrDefault();
        //    return result1 != null ? View(result1) : RedirectToAction("NotFound", "Home");
        //}
        public IActionResult Edit(int id)
        {
            var result2 = movieRepository.Get(x=>x.Id == id);
            return result2 != null ? View(result2) : RedirectToAction("NotFound", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie) 
        {
            movieRepository.Edit(movie);
            movieRepository.Commit();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result3 = movieRepository.Get(x=>x.Id == id).FirstOrDefault();
            if(result3 != null)
            {
                movieRepository.Delete(result3);
                movieRepository.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("NotFound","Home");
            }
        }
        public IActionResult Search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return View("Search", new List<Movie>());
            }

            var movies = movieRepository.Get(x => x.Name == name);                 

            return View("Search", movies);
        }


    }
}
