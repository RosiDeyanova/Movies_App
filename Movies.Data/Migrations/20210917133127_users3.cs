using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies_App.Migrations
{
    public partial class users3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Nickname", "Password", "Summary" },
                values: new object[] { 1, "admin@movies.bg", true, "admin", "1234", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
