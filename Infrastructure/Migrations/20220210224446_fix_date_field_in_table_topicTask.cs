using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class fix_date_field_in_table_topicTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "TopicTasks");

            migrationBuilder.AddColumn<long>(
                name: "DateTimestamp",
                table: "TopicTasks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimestamp",
                table: "TopicTasks");

            migrationBuilder.AddColumn<int>(
                name: "Data",
                table: "TopicTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
