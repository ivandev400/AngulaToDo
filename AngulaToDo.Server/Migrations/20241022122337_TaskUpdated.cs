using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngulaToDo.Server.Migrations
{
    /// <inheritdoc />
    public partial class TaskUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsImportant",
                table: "Tasks",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsImportant",
                table: "Tasks");
        }
    }
}
