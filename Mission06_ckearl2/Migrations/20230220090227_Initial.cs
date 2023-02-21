using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission06_ckearl2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.MovieID);
                    table.ForeignKey(
                        name: "FK_movies_categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Comedy" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Action" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Romance" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Drama" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 5, "Documentary" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 6, "Animation" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieID", "CategoryID", "Edited", "LentTo", "Notes", "Rating", "Title" },
                values: new object[] { 1, 1, false, "-", "This movie is based in Chicago", "PG-13", "Ferris Bueller's Day Off" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieID", "CategoryID", "Edited", "LentTo", "Notes", "Rating", "Title" },
                values: new object[] { 2, 1, false, "-", "Jack Black is my hero", "PG-13", "School of Rock" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieID", "CategoryID", "Edited", "LentTo", "Notes", "Rating", "Title" },
                values: new object[] { 3, 1, false, "Scotty Smalls", "A cult classic", "PG", "The Sandlot" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieID", "CategoryID", "Edited", "LentTo", "Notes", "Rating", "Title" },
                values: new object[] { 4, 4, true, "J.K. Simmons", "GOAT movie", "R", "Whiplash" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieID", "CategoryID", "Edited", "LentTo", "Notes", "Rating", "Title" },
                values: new object[] { 5, 4, true, "Matt Damon", "The most stacked cast of all time", "R", "Good Will Hunting" });

            migrationBuilder.CreateIndex(
                name: "IX_movies_CategoryID",
                table: "movies",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
