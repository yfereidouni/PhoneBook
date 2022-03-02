using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBook.Endpoints.UI.MVC.Migrations
{
    public partial class badPasswords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BadPasswords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadPasswords", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BadPasswords",
                columns: new[] { "Id", "Password" },
                values: new object[,]
                {
                    { 1, "123" },
                    { 2, "123456" },
                    { 3, "123456789" },
                    { 4, "0123456789" },
                    { 5, "1234567890" },
                    { 6, "AAA" },
                    { 7, "BBB" },
                    { 8, "CCC" },
                    { 9, "ABC" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BadPasswords");
        }
    }
}
