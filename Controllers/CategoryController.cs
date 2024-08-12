using ETickets.Models;
using ETickets.Repository;
using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
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
            var result = categoryRepository.GetOne(id);
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
            var result = categoryRepository.GetOne(id);
            categoryRepository.Delete(result);
            categoryRepository.Commit();
            return RedirectToAction("Index");
        }

    }
}
