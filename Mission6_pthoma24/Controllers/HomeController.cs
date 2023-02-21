using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6_pthoma24.Models;

namespace Mission6_pthoma24.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _movieContext { get; set; }

        // Constructor
        public HomeController(MovieContext mc)
        {
            _movieContext = mc;
        }

        // Return the Index view
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        // Return the EnterMovie view
        public IActionResult EnterMovie()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        
        // Given a valid movie entry, add the entry to the database _movieContext and return the Confirmation view along with the entry name
        public IActionResult EnterMovie(MovieEntry me)
        {
            if (ModelState.IsValid) // If entry is valid
            {
                _movieContext.Add(me);
                _movieContext.SaveChanges();

                return View("Confirmation", me);
            }
            else // If entry is invalid
            {
                return View(me);
            }
        }

        // Return the ViewPodcasts view
        public IActionResult ViewPodcasts()
        {
            return View();
        }

        // Return a list of the movie entries to the MovieList view, ordered by title
        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = _movieContext.Entries
                .Include(x => x.Category) // Includes the "Category" object in the view that is returned so that attributes of the object can be accessed
                .OrderBy(x => x.Title) // Orders the table by "Title"
                .ToList(); // Puts all the entries into a list

            return View(movies);
        }

        // Function to edit table row (Get)
        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            var entry = _movieContext.Entries.Single(x => x.MovieId == movieid);

            return View("EnterMovie", entry); // return the "Enter Movie" page view algon with the record for the single entry
        }

        // Function to edit table row (Post)
        [HttpPost]
        public IActionResult Edit (MovieEntry me)
        {
            _movieContext.Update(me);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList"); // Go back to the "MovieEntry" action and rerun the process to print out all the results. Simply returning the page view here results in an error
        }

        // Function to delete table row (Get)
        [HttpGet]
        public IActionResult Delete (int movieid)
        {
            var movie = _movieContext.Entries.Single(x => x.MovieId == movieid);
            
            return View(movie);
        }

        // Function to delete table row (Post)
        [HttpPost]
        public IActionResult Delete (MovieEntry me)
        {
            _movieContext.Entries.Remove(me);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
