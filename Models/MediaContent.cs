using csharp_boolflix.Models;

namespace csharp_boolflix.Models
{
    public class MediaContent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RunningTime { get; set; }
        public string Description { get; set; }
        public int VisualizationCount { get; set; }

        
    }
}
public class Actor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<MediaInfo> MediaInfos { get; set; }
}
public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<MediaInfo> MediaInfos { get; set; }

}
public class Feature
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<MediaInfo> MediaInfos { get; set; }

}

public class MediaInfo
{
    public int MediaInfoId { get; set; }
    public string Year { get; set; }
    public bool IsNew { get; set; }
    //public string VideoQuality { get; set; }
    public int? TVSeriesId { get; set; }
    public TVSeries? Serie { get; set; }
    public int? FilmId { get; set; }
    public Film? Film { get; set; }
    public List<Actor> Cast { get; set; }
    public List<Genre> Genres { get; set; }
    public List<Feature> Features { get; set; }


}
public class TVSeries : MediaContent
{
    public int SeasonCount { get; set; }
    //public int EpisodeNumber { get; set; }
    public MediaInfo MediaInfo { get; set; }
    public List<Episode> Episodes { get; set; }
}
public class Film : MediaContent
{
    public MediaInfo MediaInfo { get; set; }

}
public class Episode : MediaContent
{
    public int SeasonNumber { get; set; }
    public int TVSeriesId { get; set; }
    public TVSeries TVSerie { get; set; }
}