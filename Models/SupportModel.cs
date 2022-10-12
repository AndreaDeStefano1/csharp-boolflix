namespace csharp_boolflix.Models
{
    public class SupportModel
    {
        public Film? Film { get; set; }
        public List<Film>? FilmList { get; set; }
        public TVSeries? Serie { get; set; }
        public List<TVSeries>? SerieList { get; set; }
        public List<Actor>? Actors { get; set; }
        public List<int> SelectedActorsIds { get; set; } = new List<int>();
        public List<Genre>? Genres { get; set; }
        public List<int> SelectedGenresIds { get; set; } = new List<int>();

        public List<Feature>? Features { get; set; }
        public List<int> SelectedFeaturesIds { get; set; } = new List<int>();

    }
}
