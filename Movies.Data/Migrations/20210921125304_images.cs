using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies_App.Migrations
{
    public partial class images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovie",
                table: "UserMovie");

            migrationBuilder.DropColumn(
                name: "UserMovieId",
                table: "UserMovie");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserMovie",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Movie",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovie",
                table: "UserMovie",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovie",
                table: "UserMovie");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserMovie");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "UserMovieId",
                table: "UserMovie",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovie",
                table: "UserMovie",
                column: "UserMovieId");
        }
    }
}
