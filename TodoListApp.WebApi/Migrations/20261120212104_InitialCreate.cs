using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoListApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoListShares",
                columns: table => new
                {
                    TodoListId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoListShares", x => new { x.TodoListId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TodoListShares_TodoLists_TodoListId",
                        column: x => x.TodoListId,
                        principalTable: "TodoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TodoTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AssigneeId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TodoListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoTasks_TodoLists_TodoListId",
                        column: x => x.TodoListId,
                        principalTable: "TodoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TodoTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_TodoTasks_TodoTaskId",
                        column: x => x.TodoTaskId,
                        principalTable: "TodoTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TodoTaskTags",
                columns: table => new
                {
                    TodoTaskId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTaskTags", x => new { x.TodoTaskId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TodoTaskTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TodoTaskTags_TodoTasks_TodoTaskId",
                        column: x => x.TodoTaskId,
                        principalTable: "TodoTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "urgent" },
                    { 2, "work" },
                    { 3, "personal" }
                });

            migrationBuilder.InsertData(
                table: "TodoLists",
                columns: new[] { "Id", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, "Tasks related to work projects", "user-1", "Work" },
                    { 2, "Household chores", "user-1", "Home" },
                    { 3, "University assignments", "user-2", "Study" }
                });

            migrationBuilder.InsertData(
                table: "TodoListShares",
                columns: new[] { "TodoListId", "UserId", "Role" },
                values: new object[,]
                {
                    { 1, "user-2", "Editor" },
                    { 1, "user-3", "Viewer" },
                    { 3, "user-1", "Viewer" }
                });

            migrationBuilder.InsertData(
                table: "TodoTasks",
                columns: new[] { "Id", "AssigneeId", "CreatedDate", "Description", "DueDate", "Status", "Title", "TodoListId" },
                values: new object[,]
                {
                    { 1, "user-1", new DateTime(2026, 11, 1, 9, 0, 0, 0, DateTimeKind.Utc), "Summarize completed stories", new DateTime(2026, 11, 20, 18, 0, 0, 0, DateTimeKind.Utc), "InProgress", "Prepare sprint report", 1 },
                    { 2, "user-2", new DateTime(2026, 11, 2, 10, 0, 0, 0, DateTimeKind.Utc), "Review pull requests from the team", new DateTime(2026, 11, 15, 18, 0, 0, 0, DateTimeKind.Utc), "NotStarted", "Code review", 1 },
                    { 3, "user-1", new DateTime(2026, 11, 3, 8, 0, 0, 0, DateTimeKind.Utc), "Milk, bread, eggs", null, "Completed", "Buy groceries", 2 },
                    { 4, "user-2", new DateTime(2026, 11, 4, 12, 0, 0, 0, DateTimeKind.Utc), "Lab work on process memory", new DateTime(2026, 11, 25, 23, 59, 0, 0, DateTimeKind.Utc), "NotStarted", "Finish OS lab", 3 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "Text", "TodoTaskId" },
                values: new object[,]
                {
                    { 1, "user-1", new DateTime(2026, 11, 2, 9, 30, 0, 0, DateTimeKind.Utc), "Started working on it", 1 },
                    { 2, "user-2", new DateTime(2026, 11, 3, 11, 0, 0, 0, DateTimeKind.Utc), "Need data from analytics", 1 },
                    { 3, "user-1", new DateTime(2026, 11, 3, 19, 0, 0, 0, DateTimeKind.Utc), "Done, everything bought", 3 }
                });

            migrationBuilder.InsertData(
                table: "TodoTaskTags",
                columns: new[] { "TagId", "TodoTaskId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TodoTaskId",
                table: "Comments",
                column: "TodoTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoTasks_TodoListId",
                table: "TodoTasks",
                column: "TodoListId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoTaskTags_TagId",
                table: "TodoTaskTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "TodoListShares");

            migrationBuilder.DropTable(
                name: "TodoTaskTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "TodoTasks");

            migrationBuilder.DropTable(
                name: "TodoLists");
        }
    }
}
