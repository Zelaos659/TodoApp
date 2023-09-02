using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Migrations
{
    /// <inheritdoc />
    public partial class TaskForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "todoTasks",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_todoTasks_UserId",
                table: "todoTasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_todoTasks_AspNetUsers_UserId",
                table: "todoTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todoTasks_AspNetUsers_UserId",
                table: "todoTasks");

            migrationBuilder.DropIndex(
                name: "IX_todoTasks_UserId",
                table: "todoTasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "todoTasks");
        }
    }
}
