using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeMangaTracker.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public List<AnimeUser> Watchlist { get; set; } = new();
        public List<MangaUser> Readlist { get; set; } = new();
    }
}