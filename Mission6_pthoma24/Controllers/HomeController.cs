using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6_pthoma24.Models;

namespace Mission6_pthoma24.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext _movieContext { get; set; }

        // Constructor
        public HomeController(ILogger<HomeController> logger, MovieContext mc)
        {
            _logger = logger;
            _movieContext = mc;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovie(MovieEntry me)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(me);
                _movieContext.SaveChanges();

                return View("Confirmation", me);
            }
            else
            {
                return View(me);
            }
        }
        public IActionResult ViewPodcasts()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
