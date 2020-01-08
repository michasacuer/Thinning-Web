using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Thinning.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Algorithms",
                columns: table => new
                {
                    AlgorithmId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Algorithms", x => x.AlgorithmId);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivationStatusCode = table.Column<int>(nullable: false),
                    ActivationUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestId);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(nullable: false),
                    AlgorithmId = table.Column<int>(nullable: true),
                    ImageContent = table.Column<byte[]>(nullable: true),
                    OriginalWidth = table.Column<int>(nullable: false),
                    OriginalHeight = table.Column<int>(nullable: false),
                    OriginalBpp = table.Column<int>(nullable: false),
                    TestImage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Algorithms_AlgorithmId",
                        column: x => x.AlgorithmId,
                        principalTable: "Algorithms",
                        principalColumn: "AlgorithmId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestLines",
                columns: table => new
                {
                    TestLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(nullable: false),
                    AlgorithmId = table.Column<int>(nullable: false),
                    Iterations = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestLines", x => x.TestLineId);
                    table.ForeignKey(
                        name: "FK_TestLines_Algorithms_AlgorithmId",
                        column: x => x.AlgorithmId,
                        principalTable: "Algorithms",
                        principalColumn: "AlgorithmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestLines_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestPcInfos",
                columns: table => new
                {
                    TestPcInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(nullable: false),
                    Cpu = table.Column<string>(nullable: true),
                    Gpu = table.Column<string>(nullable: true),
                    Os = table.Column<string>(nullable: true),
                    Memory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPcInfos", x => x.TestPcInfoId);
                    table.ForeignKey(
                        name: "FK_TestPcInfos_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestRuns",
                columns: table => new
                {
                    TestRunId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestLinesId = table.Column<int>(nullable: false),
                    Time = table.Column<decimal>(nullable: false),
                    RunCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRuns", x => x.TestRunId);
                    table.ForeignKey(
                        name: "FK_TestRuns_TestLines_TestLinesId",
                        column: x => x.TestLinesId,
                        principalTable: "TestLines",
                        principalColumn: "TestLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_AlgorithmId",
                table: "Images",
                column: "AlgorithmId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_TestId",
                table: "Images",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestLines_AlgorithmId",
                table: "TestLines",
                column: "AlgorithmId");

            migrationBuilder.CreateIndex(
                name: "IX_TestLines_TestId",
                table: "TestLines",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestPcInfos_TestId",
                table: "TestPcInfos",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRuns_TestLinesId",
                table: "TestRuns",
                column: "TestLinesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "TestPcInfos");

            migrationBuilder.DropTable(
                name: "TestRuns");

            migrationBuilder.DropTable(
                name: "TestLines");

            migrationBuilder.DropTable(
                name: "Algorithms");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
