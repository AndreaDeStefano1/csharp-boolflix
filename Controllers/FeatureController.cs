using csharp_boolflix.DBContext;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace csharp_boolflix.Controllers
{
    public class FeatureController : Controller
    {
        private BoolflixDbContext _db;
        public FeatureController()
        {
            _db = new BoolflixDbContext();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feature formData)
        {
            if (!ModelState.IsValid)
            {

                return View("Create", formData);
            }

            Feature feature = new Feature();
            feature.Name = formData.Name;
            _db.Add(feature);
            _db.SaveChanges();

            return RedirectToAction("Features", "Editor");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
                Feature feature =_db.Features.Where(f => f.Id == id).First();

                return View(feature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Feature formData)
        {
                if (!ModelState.IsValid)
                {
                    
                    return View("Update", formData);
                }

                Feature feature =_db.Features.Where(feature => feature.Id == id).First();
                feature.Name = formData.Name;
                _db.SaveChanges();

                return RedirectToAction("Features", "Editor");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {          
            Feature feature = _db.Features.Find(id);
            if (feature == null)
            {
                return NotFound("Non trovato");

            }

            _db.Features.Remove(feature);
            _db.SaveChanges();

            return RedirectToAction("Features", "Editor");               

        }
    } 
}