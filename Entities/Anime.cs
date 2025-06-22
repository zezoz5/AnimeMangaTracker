using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeMangaTracker.Entities
{
    public class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int? Episodes { get; set; }
        public int? Seasons { get; set; }
        public string Status { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public double Score { get; set; }
        public required string Type { get; set; }
        public List<AnimeGenre> AnimeGenres { get; set; } = new();
        public List<AnimeUser> Watchlist { get; set; } = new();
    }
}