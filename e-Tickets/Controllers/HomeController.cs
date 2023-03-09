using System.Diagnostics;
using e_Tickets.Data;
using e_Tickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_Tickets.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db;
        public HomeController(AppDbContext context)
        {
            db=context;
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
           List<Movie> movielist= db.Movies.Include(x=>x.Cinema).ToList();

        
            return View(movielist);
        }
        [HttpPost]
        public IActionResult Index(string search)
        {
			if (!string.IsNullOrEmpty(search))
			{
				var movie= db.Movies.Include(x=>x.Cinema).Where(x => x.Name.Contains(search)).ToList();
				return View(movie);
			}
            return RedirectToAction("Error");
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