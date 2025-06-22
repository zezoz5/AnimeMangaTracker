using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeMangaTracker.Entities
{
    public class AnimeUser
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int AnimeId { get; set; }
        public Anime Anime { get; set; } = null!;

        public string Collection { get; set; } = null!;
        public string? Review { get; set; }
        public double? UserRating { get; set; }
    }
}