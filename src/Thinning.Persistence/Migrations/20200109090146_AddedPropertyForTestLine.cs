using Microsoft.EntityFrameworkCore.Migrations;

namespace Thinning.Persistence.Migrations
{
    public partial class AddedPropertyForTestLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AvgExecutionTime",
                table: "TestLines",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgExecutionTime",
                table: "TestLines");
        }
    }
}
