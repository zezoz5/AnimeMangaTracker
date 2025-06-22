using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeMangaTracker.Entities
{
    public class MangaGenre
    {
        public int MangaId { get; set; }
        public Manga Manga { get; set; } = null!;
        public int GenreId { get; set; }
        public  Genre Genre { get; set; } = null!;
    }
}