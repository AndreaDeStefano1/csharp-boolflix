namespace csharp_boolflix.Models
{
    public class MediaContent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RunningTime { get; set; }
        public string Description { get; set; }
        public int? VisualizationCount { get; set; } = 0;

        
    }
}
