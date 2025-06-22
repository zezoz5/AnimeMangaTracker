using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeMangaTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeMangaTracker.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=zezoz\\DATABASE1;initial catalog=AnimeMangaTracker;trusted_connection=true;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimeUser>()
            .HasKey(ua => new { ua.UserId, ua.AnimeId });

            modelBuilder.Entity<AnimeUser>()
            .HasOne(ua => ua.User)
            .WithMany(ua => ua.Watchlist)
            .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<AnimeUser>()
            .HasOne(ua => ua.Anime)
            .WithMany()
            .HasForeignKey(ua => ua.AnimeId);




            modelBuilder.Entity<MangaUser>()
            .HasKey(um => new { um.UserId, um.MangaId });

            modelBuilder.Entity<MangaUser>()
            .HasOne(um => um.User)
            .WithMany(um => um.Readlist)
            .HasForeignKey(um => um.UserId);

            modelBuilder.Entity<MangaUser>()
            .HasOne(um => um.Manga)
            .WithMany()
            .HasForeignKey(um => um.MangaId);



            modelBuilder.Entity<AnimeGenre>()
            .HasKey(ag => new { ag.AnimeId, ag.GenreId });

            modelBuilder.Entity<AnimeGenre>()
            .HasOne(ag => ag.Anime)
            .WithMany(a => a.AnimeGenres)
            .HasForeignKey(ag => ag.AnimeId);

            modelBuilder.Entity<AnimeGenre>()
            .HasOne(ag => ag.Genre)
            .WithMany(a => a.AnimeGenres)
            .HasForeignKey(ag => ag.GenreId);



            modelBuilder.Entity<MangaGenre>()
            .HasKey(mg => new { mg.MangaId, mg.GenreId });

            modelBuilder.Entity<MangaGenre>()
            .HasOne(mg => mg.Manga)
            .WithMany(mg => mg.MangaGenres)
            .HasForeignKey(mg => mg.MangaId);

            modelBuilder.Entity<MangaGenre>()
            .HasOne(mg => mg.Genre)
            .WithMany(mg => mg.MangaGenres)
            .HasForeignKey(mg => mg.GenreId);


            
        }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AnimeUser> AnimeUsers { get; set; }
        public DbSet<MangaUser> MangaUsers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<AnimeGenre> AnimeGenres { get; set; }
        public DbSet<MangaGenre> MangaGenres { get; set; }

    }
}