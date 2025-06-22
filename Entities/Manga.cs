using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeMangaTracker.Entities
{
    public class Manga
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int? Chapters { get; set; }
        public required string Status { get; set; }
        public int ReleaseYear { get; set; }
        public double Score { get; set; }
        public List<MangaUser> Readlist { get; set; } = new();
        public List<MangaGenre> MangaGenres { get; set; } = new();
    }
}