using csharp_boolflix.DBContext;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    public class EpisodeController : Controller
    {



        private BoolflixDbContext _db;
        public EpisodeController()
        {
            _db = new BoolflixDbContext();
        }

        public IActionResult Create(int id)
        {
            TVSeries tvSerie = _db.TvSeries.Find(id);

            SupportModel supportModel = new SupportModel();
            supportModel.TvSerie = tvSerie;
            supportModel.tvSerieId = id;


            return View(supportModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SupportModel model)
        {

            if (!ModelState.IsValid)
            {
                model.TvSerie = _db.TvSeries.Find(model.tvSerieId);
                return View("Create", model);
            }

            model.Episode.TVSerie = _db.TvSeries.Find(model.tvSerieId);

            _db.Add(model.Episode);
            _db.SaveChanges();

            return RedirectToAction("Series", "Editor");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Actor actor = _db.Actors.Find(id);

            if (actor == null)
            {
                return NotFound("Non è stato possibile trovare l'attore da modificare");
            }
            else
            {
                return View(actor);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Actor model)
        {

            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            Actor actor = _db.Actors.Find(id);

            actor.Name = model.Name;
            actor.Surname = model.Surname;

            _db.SaveChanges();

            return RedirectToAction("Series", "Editor");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Actor actor = _db.Actors.Find(id);

            if (actor == null)
            {
                return NotFound();
            }
            else
            {
                _db.Actors.Remove(actor);
                _db.SaveChanges();

                return RedirectToAction("Series", "Editor");
            }

        }
        
    }

}
