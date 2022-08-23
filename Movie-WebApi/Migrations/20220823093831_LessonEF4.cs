using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_WebApi.Migrations
{
    public partial class LessonEF4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reviews",
                newName: "ReviewId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movies",
                newName: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Reviews",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Movies",
                newName: "Id");
        }
    }
}
