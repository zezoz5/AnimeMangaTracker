using AnimeMangaTracker;
using AnimeMangaTracker.Entities;
using AnimeMangaTracker.Data;
using Microsoft.EntityFrameworkCore;
using AnimeMangaTracker.Helpers;


class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();

        var MyReadlist = context.MangaUsers.Include(mu=>mu.Manga).ToList();

        foreach (var Manga in MyReadlist)
        {
            System.Console.WriteLine($"Name: {Manga.Manga.Title}, Collection: {Manga.Collection}, Rating: {Manga.UserRating}, Review: {Manga.Review}");
        };
    }

}