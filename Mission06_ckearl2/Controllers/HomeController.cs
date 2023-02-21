using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_ckearl2.Models;
using System.Linq;

namespace Mission06_ckearl2.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext movieContext { get; set; }

        // Constructor
        public HomeController( MovieContext mcontext)
        {
            movieContext = mcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = movieContext.categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie mv)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(mv);
                movieContext.SaveChanges();

                return View("AllMovies", mv);
            }
            else
            {
                ViewBag.Categories = movieContext.categories.ToList();
                return View(mv);
            }
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        public IActionResult BaconSale()
        {
            return Redirect("https://baconsale.com/");
        }

        [HttpGet]
        public IActionResult MovieTable()
        {
            var movies = movieContext.movies
                .Include(item => item.Category)
                // .Where(item => item.Edited == false)
                .OrderBy(item => item.Title)
                .ToList();
            
            return View(movies);
        }

        [HttpGet]
        public IActionResult EditMovie (int movieid)
        {
            ViewBag.Categories = movieContext.categories.ToList();

            var movie = movieContext.movies.Single(item => item.MovieID == movieid);

            return View("AddMovie", movie);
        }

        [HttpPost]
        public IActionResult EditMovie (Movie mv)
        {
            movieContext.Update(mv);
            movieContext.SaveChanges();
            return RedirectToAction("MovieTable");
        }

        [HttpGet]
        public IActionResult DeleteMovie (int movieid)
        {
            var movie = movieContext.movies.Single(item => item.MovieID == movieid);
            
            return View(movie);
        }

        [HttpPost]
        public IActionResult DeleteMovie (Movie mv)
        {
            movieContext.movies.Remove(mv);
            movieContext.SaveChanges();
            return RedirectToAction("MovieTable");
        }


    }
}
