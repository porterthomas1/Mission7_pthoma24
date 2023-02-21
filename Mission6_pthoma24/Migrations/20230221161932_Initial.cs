using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission6_pthoma24.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<short>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    Lent_to = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Entries_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Fantasy/Adventure" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Action" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Sci-Fi" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "MovieId", "CategoryId", "Director", "Edited", "Lent_to", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, 1, "Peter Jackson", false, "", "10/10", "PG-13", "The Lord of the Rings: The Fellowship of the Ring", (short)2001 });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "MovieId", "CategoryId", "Director", "Edited", "Lent_to", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, 1, "Peter Jackson", false, "", "10/10", "PG-13", "The Lord of the Rings: The Two Towers", (short)2002 });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "MovieId", "CategoryId", "Director", "Edited", "Lent_to", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, 1, "Peter Jackson", false, "", "10/10", "PG-13", "The Lord of the Rings: The Return of the King", (short)2003 });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_CategoryId",
                table: "Entries",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
