using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebpackBundleInfo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bundles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommitSha = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommitTimestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TotalParsedSize = table.Column<long>(type: "bigint", nullable: false),
                    TotalGzipSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BundleComponents",
                columns: table => new
                {
                    BundleId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatSize = table.Column<long>(type: "bigint", nullable: false),
                    ParsedSize = table.Column<long>(type: "bigint", nullable: false),
                    GzipSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BundleComponents", x => new { x.BundleId, x.Id });
                    table.ForeignKey(
                        name: "FK_BundleComponents_Bundles_BundleId",
                        column: x => x.BundleId,
                        principalTable: "Bundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bundles_CommitSha",
                table: "Bundles",
                column: "CommitSha",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BundleComponents");

            migrationBuilder.DropTable(
                name: "Bundles");
        }
    }
}
