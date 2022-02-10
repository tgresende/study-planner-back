using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class create_table_topicTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TopicTasks",
                columns: table => new
                {
                    TopicTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicId = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevisionItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoneQuestionQuantity = table.Column<int>(type: "int", nullable: false),
                    CorrectQuestionQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicTasks", x => x.TopicTaskId);
                    table.ForeignKey(
                        name: "FK_TopicTasks_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicTasks_TopicId",
                table: "TopicTasks",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicTasks");
        }
    }
}