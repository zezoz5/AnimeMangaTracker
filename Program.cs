using AnimeMangaTracker;
using AnimeMangaTracker.Entities;
using AnimeMangaTracker.Data;
using Microsoft.EntityFrameworkCore;
using AnimeMangaTracker.Helpers;
using Microsoft.IdentityModel.Tokens;
using Azure.Identity;


class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();

        while (true)
        {
            System.Console.WriteLine("\n --- Welcome to my Manga library! ---\n");
            System.Console.WriteLine("1. Search the manga you want.");
            System.Console.WriteLine("2. View your readlist.");
            System.Console.WriteLine("3. View all Mangas sorted by Genre.");
            System.Console.WriteLine("4. View all Mangas sorted by your Collection.");
            System.Console.WriteLine("5. View all Mangas sorted by Score.");
            System.Console.WriteLine("6. Exit. \n");
            System.Console.Write("Pick up what you want to do: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    SearchManga(context);
                    break;

                case "2":
                    MangaUserReadlist(context);
                    break;


                case "3":
                    FilterMangaByGenre(context);
                    break;

                case "4":
                    FilterMangaByCollection(context);
                    break;

                case "5":
                    FilterMangaByScore(context);
                    break;

                case "6":
                    return;

                default:
                    System.Console.WriteLine("⚠️ Please enter a number between 1 and 6.");
                    break;
            }
            System.Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();

        }


    }

    // --- Search by title ---
    static void SearchManga(AppDbContext context)
    {
        System.Console.Write("\n🔍 ");
        string? MangaName = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(MangaName))
        {
            var Keyword = context.Mangas
            .Where(mn => mn.Title.Contains(MangaName))
            .ToList();

            if (Keyword.IsNullOrEmpty())
            {
                Console.WriteLine("Manga not found");
            }

            else
            {
                foreach (var manga in Keyword)
                {
                    System.Console.WriteLine(manga.Title);
                }
            }
        }
        else
        {
            System.Console.WriteLine("Enter a valid Manga title");
        }
    }

    // --- User Manga readlist ---
    static void MangaUserReadlist(AppDbContext context)
    {
        Console.Write("\nEnter your User Name: ");
        string? Username = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(Username))
        {
            var MyReadlist = context.MangaUsers
            .Include(mu => mu.Manga)
            .Where(u => u.User.Username.Contains(Username))
            .ToList();

            System.Console.WriteLine();
            foreach (var Manga in MyReadlist)
            {
                System.Console.WriteLine($"{Manga.Manga.Title}, Collection: {Manga.Collection}, Your rating: {Manga.UserRating}, Review: {Manga.Review}");
            }

        }
        else
        {
            System.Console.WriteLine("Invalid User name");
        }
    }

    // --- Filter by Genre ---
    static void FilterMangaByGenre(AppDbContext context)
    {
        System.Console.Write("\nEnter the genre you want to sort by: ");
        string? Genre = Console.ReadLine();
        System.Console.WriteLine();

        if (!string.IsNullOrWhiteSpace(Genre))
        {
            var genreFilter = context.MangaGenres
            .Include(mg => mg.Manga)
            .Where(g => g.Genre.Name.Contains(Genre))
            .ToList();

            foreach (var manga in genreFilter)
            {
                System.Console.WriteLine($"{manga.Manga.Title}");
            }
        }
        else
        {
            System.Console.WriteLine("Genre not found");
        }
    }

    // --- Filter by Collection ---
    static void FilterMangaByCollection(AppDbContext context)
    {
        var FilterCollection = context.MangaUsers
        .Include(mu => mu.Manga)
        .OrderBy(mu => mu.Collection)
        .ToList();

        System.Console.WriteLine();
        foreach (var manga in FilterCollection)
        {
            System.Console.WriteLine($"{manga.Manga.Title} - {manga.Collection}");
        }
    }

    // --- Sort by Score ---
    static void FilterMangaByScore(AppDbContext context)
    {
        var ratingSort = context.Mangas
            .OrderByDescending(ms => ms.Score)
            .ToList();

        System.Console.WriteLine();
        foreach (var manga in ratingSort)
        {
            System.Console.WriteLine($"{manga.Title} - Rating: {manga.Score}");
        }
    }


}