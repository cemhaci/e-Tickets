using e_Tickets.Data;
using e_Tickets.Data.Services;
using e_Tickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_Tickets.Controllers
{
    public class ProducerController : Controller
    {
        IRepository<Producer> _producer;  

        public ProducerController(IRepository<Producer> producer)
        {
            _producer = producer;
        }
        public IActionResult Index()
        {
            List<Producer> producer=_producer.GetAll();
            return View(producer);
        }
		public IActionResult Details(int id)
		{
			var producer = _producer.GetById(id);
			if (producer == null)
				return View("PartialPage");
			return View(producer);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create([Bind("FullName,ProfilePictureUrl,Bio")] Producer producer, IFormFile profileImage)
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
				producer.ProfilePictureUrl = yol;

				_producer.Add(producer);


				return RedirectToAction("Index");
			}
			return View("Index");
		}
		public IActionResult Edit(int id)
		{
			Producer producerEdit = _producer.GetById(id);
			if (producerEdit == null) return View("PartialPage");
			return View(producerEdit);
		}
		[HttpPost]
		public IActionResult Edit(Producer newproducer, IFormFile profileImage1)
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
				newproducer.ProfilePictureUrl = yol;

				_producer.Update(newproducer);
				return RedirectToAction("Index");
			}
			return View(newproducer);
		}

		public IActionResult Delete(int id)
		{
			Producer producerEdit = _producer.GetById(id);
			if (producerEdit == null) return View("PartialPage");
			_producer.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
