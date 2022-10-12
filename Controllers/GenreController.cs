using csharp_boolflix.DBContext;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace csharp_boolflix.Controllers
{
    public class GenreController : Controller
    {
        private BoolflixDbContext _db;
        public GenreController()
        {
            _db = new BoolflixDbContext();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre formData)
        {
            if (!ModelState.IsValid)
            {

                return View("Create", formData);
            }

            Genre genre = new Genre();
            genre.Name = formData.Name;
            _db.Add(genre);
            _db.SaveChanges();

            return RedirectToAction("Genres", "Editor");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Genre genre = _db.Genres.Where(g => g.Id == id).First();

            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Genre formData)
        {
            if (!ModelState.IsValid)
            {
                    
                return View("Update", formData);
            }

            Feature genre = _db.Features.Where(genre => genre.Id == id).First();
            genre.Name = formData.Name;
            _db.SaveChanges();

            return RedirectToAction("Features", "Editor");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {          
            Genre genre = _db.Genres.Find(id);
            if (genre == null)
            {
                return NotFound("Non trovato");

            }

            _db.Genres.Remove(genre);
            _db.SaveChanges();

            return RedirectToAction("Genres", "Editor");               

        }
    } 
}