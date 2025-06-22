using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeMangaTracker.Entities
{
    public class AnimeGenre
    {
        public int AnimeId { get; set; }
        public Anime Anime { get; set; } = null!;
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
    }
}