using Microsoft.EntityFrameworkCore.Migrations;

namespace Reshare_proto_0._2.Migrations.Geo
{
    public partial class GeoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dim");

            migrationBuilder.CreateTable(
                name: "tblCountry",
                schema: "dim",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCountry", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "tblState",
                schema: "dim",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblState", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_tblState_tblCountry_CountryId1",
                        column: x => x.CountryId1,
                        principalSchema: "dim",
                        principalTable: "tblCountry",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCity",
                schema: "dim",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCity", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_tblCity_tblState_StateId",
                        column: x => x.StateId,
                        principalSchema: "dim",
                        principalTable: "tblState",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCity_StateId",
                schema: "dim",
                table: "tblCity",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_tblState_CountryId1",
                schema: "dim",
                table: "tblState",
                column: "CountryId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCity",
                schema: "dim");

            migrationBuilder.DropTable(
                name: "tblState",
                schema: "dim");

            migrationBuilder.DropTable(
                name: "tblCountry",
                schema: "dim");
        }
    }
}
