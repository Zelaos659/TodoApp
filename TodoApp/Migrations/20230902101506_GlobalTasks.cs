using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TodoApp.Migrations
{
    /// <inheritdoc />
    public partial class GlobalTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todoTasks_AspNetUsers_UserId",
                table: "todoTasks");

            migrationBuilder.DropIndex(
                name: "IX_todoTasks_UserId",
                table: "todoTasks");

            migrationBuilder.DropColumn(
                name: "User",
                table: "todoTasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "todoTasks");

            migrationBuilder.AlterColumn<string>(
                name: "TaskName",
                table: "todoTasks",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "globalTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskName = table.Column<string>(type: "text", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_globalTasks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "globalTasks");

            migrationBuilder.AlterColumn<string>(
                name: "TaskName",
                table: "todoTasks",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "todoTasks",
                type: "text",
                nullable: false,
                defaultValue: "");

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
    }
}
