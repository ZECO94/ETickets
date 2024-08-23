using ETickets.Models;
using ETickets.Repository;
using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMovieRepository movieRepository;
        public CategoryController(ICategoryRepository categoryRepository,
            IMovieRepository movieRepository)
        {
            this.categoryRepository = categoryRepository;
            this.movieRepository = movieRepository;
        }
        [AllowAnonymous]
       public IActionResult Index()
       {
            var result = categoryRepository.GetAll();
            return View(result);
       }
        
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Create(category);
                categoryRepository.Commit();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Edit(int id)
        {
            var result = categoryRepository.Get(x=>x.Id == id).FirstOrDefault();
            return result != null ? View(result) : RedirectToAction("NotFound","Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category) 
        {
            categoryRepository.Edit(category);
            categoryRepository.Commit();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result = categoryRepository.Get(x=>x.Id == id).FirstOrDefault();
            if (result != null)
            {
                categoryRepository.Delete(result);
                categoryRepository.Commit();
                return RedirectToAction("Index");
            } else
            {
                return RedirectToAction("NotFound","Home");
            }
        }
        [AllowAnonymous]
        public IActionResult AllMovies(int id)
        {
            var result = movieRepository.Get(x => x.CategoryId == id, x => x.Category
            ,x=>x.Cinema);
            return View(result);
        }

    }
}
