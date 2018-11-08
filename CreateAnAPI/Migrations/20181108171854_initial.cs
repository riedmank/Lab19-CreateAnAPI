using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreateAnAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ListTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    IsDone = table.Column<bool>(nullable: false),
                    TodoListID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Todos_TodoLists_TodoListID",
                        column: x => x.TodoListID,
                        principalTable: "TodoLists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TodoLists",
                columns: new[] { "ID", "ListTitle" },
                values: new object[] { 1, "tasks" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "ID", "IsDone", "Title", "TodoListID" },
                values: new object[] { 1, false, "write code", 1 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "ID", "IsDone", "Title", "TodoListID" },
                values: new object[] { 2, true, "squish the cat", 1 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "ID", "IsDone", "Title", "TodoListID" },
                values: new object[] { 3, false, "wash dishes", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_TodoListID",
                table: "Todos",
                column: "TodoListID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "TodoLists");
        }
    }
}
