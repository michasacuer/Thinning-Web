using Microsoft.EntityFrameworkCore.Migrations;

namespace Thinning.Persistence.Migrations
{
    public partial class RelationTestLineToImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestLineId",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_TestLineId",
                table: "Images",
                column: "TestLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_TestLines_TestLineId",
                table: "Images",
                column: "TestLineId",
                principalTable: "TestLines",
                principalColumn: "TestLineId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_TestLines_TestLineId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_TestLineId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "TestLineId",
                table: "Images");
        }
    }
}
