﻿using ETickets.Models;
using ETickets.Repository;
using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    [Authorize(Roles ="Admin")]
    
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;
        
        public MovieController (IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var result = movieRepository.GetAll(x=>x.Category , x=>x.Cinema);
            return View(result);
        }
        [AllowAnonymous]
        //public IActionResult Details(int id)//DATABASE ISSUE TO BE CHECKED
        //{
        //    var result1 = movieRepository.Get(x => x.Id == id, x => x.Category,
        //        x => x.Cinema, x => x.Actors).FirstOrDefault();
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
        [AllowAnonymous]
        public IActionResult Search(string query)
        {
            var movie =movieRepository.Get(x=>x.Name == query ,x => x.Category, x => x.Cinema);
            return View("Index" , movie);
        }


    }
}
