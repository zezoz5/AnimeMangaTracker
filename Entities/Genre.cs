using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeMangaTracker.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<AnimeGenre> AnimeGenres { get; set; } = new();
        public List<MangaGenre> MangaGenres { get; set; } = new();
    }
}