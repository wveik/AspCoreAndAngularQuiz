using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class UpdateQyestionWrongAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WrongAnswer1",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WrongAnswer2",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WrongAnswer3",
                table: "Questions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WrongAnswer1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "WrongAnswer2",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "WrongAnswer3",
                table: "Questions");
        }
    }
}
