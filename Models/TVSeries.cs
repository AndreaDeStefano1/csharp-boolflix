using csharp_boolflix.Models;

public class TVSeries : MediaContent
{
    public int SeasonCount { get; set; }
    //public int EpisodeNumber { get; set; }
    public MediaInfo MediaInfo { get; set; }
    public List<Episode> Episodes { get; set; }
}
