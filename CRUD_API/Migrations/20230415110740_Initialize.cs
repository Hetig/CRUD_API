using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRUD_API.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resident",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resident", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Resident",
                columns: new[] { "Id", "Name", "Sex" },
                values: new object[,]
                {
                    { "acmwojeiwqe9", "Anna Titova", "female" },
                    { "ajkvdnLdj22po11", "Pishkun Vladislav", "male" },
                    { "cnoqjpIdjkqpo11", "Sascha Braemer", "male" },
                    { "djkqpo11cnoqjpI", "Jessica Braemer", "female" },
                    { "guyqwhoij6", "Dmitry Vegas", "male" },
                    { "hqwuiehquikxhc5", "German Titov", "male" },
                    { "kjlqwoijeo7", "Solomon Shlemovich", "male" },
                    { "lkkpokqw8", "Alex Whitedrinker", "female" },
                    { "lkqjweiojqiow4", "Erzhena Koroleva", "female" },
                    { "qjIdwojqiowj10", "Elmo Kennedy", "male" },
                    { "qmvqqwrqsds2", "Jack Anderson", "male" },
                    { "qyfgqiyhwfoq1", "Stan Smith", "male" },
                    { "vdhgqvgj3", "Olga Popova", "female" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resident");
        }
    }
}
