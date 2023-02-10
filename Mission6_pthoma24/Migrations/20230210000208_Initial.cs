using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission6_pthoma24.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<short>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    Lent_to = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "Lent_to", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, "Fantasy/Adventure", "Peter Jackson", false, "", "10/10", "PG-13", "The Lord of the Rings: The Fellowship of the Ring", (short)2001 });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "Lent_to", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "Fantasy/Adventure", "Peter Jackson", false, "", "10/10", "PG-13", "The Lord of the Rings: The Two Towers", (short)2002 });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "Lent_to", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "Fantasy/Adventure", "Peter Jackson", false, "", "10/10", "PG-13", "The Lord of the Rings: The Return of the King", (short)2003 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
