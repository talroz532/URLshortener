namespace URLshortener.Models
{
    public class Urllist
    {
        public int Id { get; set; } // primary key
        public string? UrlLong { get; set; }
        public string? UrlShort { get; set; }
    }
}
