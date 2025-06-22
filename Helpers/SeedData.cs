using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AnimeMangaTracker.Data;
using AnimeMangaTracker.Entities;
using AnimeMangaTracker.Migrations;

namespace AnimeMangaTracker.Helpers
{
    public static class SeedData
    {
        public static void AddAnimeGenres(AppDbContext context)
        {
            


            context.SaveChanges();
        }
    }
}