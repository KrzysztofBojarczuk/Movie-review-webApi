using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_WebApi.Migrations
{
    public partial class InitialMovieClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Eeleasedate",
                table: "Movies",
                newName: "Releasedate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Releasedate",
                table: "Movies",
                newName: "Eeleasedate");
        }
    }
}
