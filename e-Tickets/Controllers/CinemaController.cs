using System.Numerics;
using e_Tickets.Data;
using e_Tickets.Data.Services;
using e_Tickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_Tickets.Controllers
{
    public class CinemaController : Controller
    {
        IRepository<Cinema> _cinema;

        public CinemaController(IRepository<Cinema> cinema)
        {
           _cinema= cinema;
        }
        public IActionResult Index()
        {
            List<Cinema> cinema=_cinema.GetAll();
            return View(cinema);
        }
        public IActionResult Details(int id)
        {
			var cinema = _cinema.GetById(id);
			if (cinema == null)
				return View("PartialPage");
			return View(cinema);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create([Bind("FullName,ProfilePictureUrl,Bio")] Cinema cinema, IFormFile profileImage)
		{
			if (ModelState.IsValid)
			{


				var extent = Path.GetExtension(profileImage.FileName);
				var randomName = ($"{Guid.NewGuid()}{extent}");

				//var paths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image", randomName);

				Stream stream = new FileStream($"wwwroot\\Image\\{randomName}", FileMode.Create);
				profileImage.CopyTo(stream);
				stream.Close();
				stream.Dispose();

				var yol = $"/Image/{randomName}";
				//byte[] resim = Encoding.UTF32.GetBytes(extent);
				cinema.logo= yol;

				_cinema.Add(cinema);


				return RedirectToAction("Index");
			}
			return View("Index");
		}
		public IActionResult Edit(int id)
		{
			Cinema cinemaEdit = _cinema.GetById(id);
			if (cinemaEdit == null) return View("PartialPage");
			return View(cinemaEdit);
		}
		[HttpPost]
		public IActionResult Edit(Cinema newcinema, IFormFile profileImage1)
		{
			if (ModelState.IsValid)
			{
				var extent = Path.GetExtension(profileImage1.FileName);
				var randomName = ($"{Guid.NewGuid()}{extent}");

				//var paths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image", randomName);

				Stream stream = new FileStream($"wwwroot\\Image\\{randomName}", FileMode.Create);
				profileImage1.CopyTo(stream);
				stream.Close();
				stream.Dispose();
				var yol = $"/Image/{randomName}";
				newcinema.logo = yol;

				_cinema.Update(newcinema);
				return RedirectToAction("Index");
			}
			return View(newcinema);
		}

		public IActionResult Delete(int id)
		{
			Cinema cinemaEdit = _cinema.GetById(id);
			if (cinemaEdit == null) return View("PartialPage");
			_cinema.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
