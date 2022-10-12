using csharp_boolflix.DBContext;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    public class EditorController : Controller
    {
        private BoolflixDbContext _db;
        public EditorController()
        {
            _db = new BoolflixDbContext();
        }
        public IActionResult Index()
        {
            return View();
        }    
        public IActionResult Films()
        {
            SupportModel supportModel = new SupportModel();
            supportModel.Actors = _db.Actors.ToList();
            supportModel.FilmList = _db.Films.ToList();
            return View(supportModel);
        }
        public IActionResult Series()
        {

            SupportModel supportModel = new SupportModel();
            supportModel.Actors = _db.Actors.ToList();
            supportModel.SerieList = _db.TvSeries.ToList();
            return View(supportModel);
        }
        public IActionResult Genres()
        {
            List<Genre> genres = _db.Genres.ToList();
            return View(genres);
        }
        public IActionResult Actors()
        {
            List<Actor> actors = _db.Actors.ToList();
            return View(actors);
        }
        public IActionResult Features()
        {
            List<Feature> features = _db.Features.ToList();
            return View(features);
        }
     

    }
}
