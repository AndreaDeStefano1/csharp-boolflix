public class MediaInfo
{
    public int MediaInfoId { get; set; }
    public string Year { get; set; }
    public bool IsNew { get; set; }
    public int? TVSeriesId { get; set; }
    public TVSeries? Serie { get; set; }
    public int? FilmId { get; set; }
    public Film? Film { get; set; }
    public List<Actor> Cast { get; set; } = new List<Actor>();
    public List<Genre> Genres { get; set; } = new List<Genre>();
    public List<Feature> Features { get; set; } = new List<Feature>(); 


}
