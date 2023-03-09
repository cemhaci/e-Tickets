using System.Net;
using System.Text;
using e_Tickets.Data;
using e_Tickets.Data.Services;
using e_Tickets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Tickets.Controllers
{
    public class ActorController : Controller
    {
        IRepository<Actor> _actor;
        public ActorController(IRepository<Actor> actor)
        { 
                _actor= actor;    
            }
        public IActionResult Actor()
        {
           List<Actor> actors = _actor.GetAll();
            return View(actors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("FullName,ProfilePictureUrl,Bio")]Actor actor,IFormFile profileImage)
        {
            if(ModelState.IsValid)
            {
                var actors = _actor.Find(x=>x.FullName==actor.FullName);
                if (actors != null)
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
                actor.ProfilePictureUrl = yol;

                _actor.Add(actor);
               
                    
                return RedirectToAction("Actor");
                }
                else
                {
                    ModelState.AddModelError(nameof(actor.FullName), "This actor is already registered");
                    return View();  
                }
          
            }
            return View(actor);
        }
        public IActionResult Details(int id) 
        {
            var actors = _actor.GetById(id);
            if (actors == null)
                return View("PartialPage");
            return View(actors);
        }
        public IActionResult Edit(int id) 
        { 
            Actor actorEdit=_actor.GetById(id);
            if (actorEdit == null) return View("PartialPage");
			return View(actorEdit);
        }
        [HttpPost]
        public IActionResult Edit(Actor newactor,IFormFile profileImage1)
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
                newactor.ProfilePictureUrl = yol;

                _actor.Update(newactor);
                return RedirectToAction("Actor");
            }
            return View(newactor);
        }
        
        public IActionResult Delete(int id)
        {
            Actor actorEdit = _actor.GetById(id);
            if (actorEdit == null) return View("PartialPage");
			_actor.Delete(id);
            return RedirectToAction("Actor");
        }
    }
}
