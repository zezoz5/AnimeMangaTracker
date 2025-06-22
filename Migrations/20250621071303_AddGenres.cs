using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeMangaTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AniemGenres_Animes_AnimeId",
                table: "AniemGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_AniemGenres_Genres_GenreId",
                table: "AniemGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AniemGenres",
                table: "AniemGenres");

            migrationBuilder.RenameTable(
                name: "AniemGenres",
                newName: "AnimeGenres");

            migrationBuilder.RenameIndex(
                name: "IX_AniemGenres_GenreId",
                table: "AnimeGenres",
                newName: "IX_AnimeGenres_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeGenres",
                table: "AnimeGenres",
                columns: new[] { "AnimeId", "GenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeGenres_Animes_AnimeId",
                table: "AnimeGenres",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeGenres_Genres_GenreId",
                table: "AnimeGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeGenres_Animes_AnimeId",
                table: "AnimeGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeGenres_Genres_GenreId",
                table: "AnimeGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeGenres",
                table: "AnimeGenres");

            migrationBuilder.RenameTable(
                name: "AnimeGenres",
                newName: "AniemGenres");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeGenres_GenreId",
                table: "AniemGenres",
                newName: "IX_AniemGenres_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AniemGenres",
                table: "AniemGenres",
                columns: new[] { "AnimeId", "GenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AniemGenres_Animes_AnimeId",
                table: "AniemGenres",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AniemGenres_Genres_GenreId",
                table: "AniemGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
