using csharp_boolflix.DBContext;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;

namespace csharp_boolflix.Controllers
{
    public class ActorController : Controller
    {
        private BoolflixDbContext _db;
        public ActorController()
        {
            _db = new BoolflixDbContext();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Actor formData)
        {
            if (!ModelState.IsValid)
            {

                return View("Create", formData);
            }

            Actor actor = new Actor();
            actor.Name = formData.Name;
            actor.Surname = formData.Surname;
            _db.Add(actor);
            _db.SaveChanges();

            return RedirectToAction("Actors", "Editor");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Actor actor = _db.Actors.Where(a => a.Id == id).First();

            return View(actor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Actor formData)
        {
            if (!ModelState.IsValid)
            {
                    
                return View("Update", formData);
            }

            Actor actor = _db.Actors.Where(actor => actor.Id == id).First();
            actor.Name = formData.Name;
            actor.Surname = formData.Surname;

            _db.SaveChanges();

            return RedirectToAction("Actors", "Editor");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Actor actor = _db.Actors.Find(id);
            if (actor == null)
            {
                return NotFound("Non trovato");

            }

            _db.Actors.Remove(actor);
            _db.SaveChanges();

            return RedirectToAction("Actors", "Editor");               

        }


    } 
}