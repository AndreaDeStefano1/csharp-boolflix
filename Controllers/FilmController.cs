using csharp_boolflix.DBContext;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace csharp_boolflix.Controllers
{
    public class FilmController : Controller
    {
        private BoolflixDbContext _db;
        public FilmController()
        {
            _db = new BoolflixDbContext();
        }

        public IActionResult Create()
        {
            SupportModel supportModel = new SupportModel();
            supportModel.Actors = _db.Actors.ToList();
            supportModel.Genres = _db.Genres.ToList();
            supportModel.Features = _db.Features.ToList();
            return View(supportModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SupportModel formData)
        {
            if (!ModelState.IsValid)
            {

                return View("Create", formData);
            }

           
            foreach (int Id in formData.SelectedActorsIds)
            {
                Actor actor = _db.Actors.Find(Id);
                formData.Film.MediaInfo.Cast.Add(actor); 
            }
            foreach (int Id in formData.SelectedGenresIds)
            {
                Genre genre = _db.Genres.Find(Id);
                formData.Film.MediaInfo.Genres.Add(genre);
            }
            foreach (int Id in formData.SelectedFeaturesIds)
            {
                Feature feature = _db.Features.Find(Id);
                formData.Film.MediaInfo.Features.Add(feature);
            }
       
           

            _db.Add(formData.Film);
            _db.SaveChanges();

            return RedirectToAction("Films", "Editor");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            SupportModel supportModel = new();
            supportModel.Film = _db.Films.Where(a => a.Id == id).First();
            supportModel.Actors = _db.Actors.ToList();
            supportModel.Genres = _db.Genres.ToList();
            supportModel.Features = _db.Features.ToList();
            supportModel.Film.MediaInfo = _db.MediaInfos.Where(s => s.FilmId == id).Include("Cast").Include("Genres").Include("Features").First();
            foreach (Feature feature in supportModel.Film.MediaInfo.Features)
            {
                supportModel.SelectedFeaturesIds.Add(feature.Id);
            }
            foreach (Actor actor in supportModel.Film.MediaInfo.Cast)
            {
                supportModel.SelectedActorsIds.Add(actor.Id);
            }
            foreach (Genre genre in supportModel.Film.MediaInfo.Genres)
            {
                supportModel.SelectedGenresIds.Add(genre.Id);
            }
            


            return View(supportModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, SupportModel formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Actors = _db.Actors.ToList();
                formData.Genres = _db.Genres.ToList();
                formData.Features = _db.Features.ToList();
                return View("Update", formData);
            }

            

            _db.SaveChanges();

            return RedirectToAction("Films", "Editor");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            MediaInfo mediaInfo = _db.MediaInfos.Where(s => s.FilmId == id).First();
            Film film = _db.Films.Find(id);

            if (mediaInfo == null)
            {
                return NotFound();
            }
            else
            {
                _db.Films.Remove(film);
                _db.MediaInfos.Remove(mediaInfo);
                _db.SaveChanges();

                return RedirectToAction("Films", "Editor");
            }

        }
    } 
}