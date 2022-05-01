using Microsoft.EntityFrameworkCore.Migrations;

namespace Reshare_proto_0._2.Migrations
{
    public partial class MainMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dim");

            migrationBuilder.CreateTable(
                name: "tblCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategory", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tblLocation",
                schema: "dim",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLocation", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_tblUser_tblLocation_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "dim",
                        principalTable: "tblLocation",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblImages",
                columns: table => new
                {
                    ImgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblImages", x => x.ImgId);
                    table.ForeignKey(
                        name: "FK_tblImages_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUserSaves",
                columns: table => new
                {
                    UserSaveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserModelUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserSaves", x => x.UserSaveId);
                    table.ForeignKey(
                        name: "FK_tblUserSaves_tblUser_UserModelUserId",
                        column: x => x.UserModelUserId,
                        principalTable: "tblUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblImageCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageModelImgId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblImageCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblImageCategories_tblCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tblCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblImageCategories_tblImages_ImageModelImgId",
                        column: x => x.ImageModelImgId,
                        principalTable: "tblImages",
                        principalColumn: "ImgId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblImageCategories_CategoryId",
                table: "tblImageCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblImageCategories_ImageModelImgId",
                table: "tblImageCategories",
                column: "ImageModelImgId");

            migrationBuilder.CreateIndex(
                name: "IX_tblImages_UserId",
                table: "tblImages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_LocationId",
                table: "tblUser",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserSaves_UserModelUserId",
                table: "tblUserSaves",
                column: "UserModelUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblImageCategories");

            migrationBuilder.DropTable(
                name: "tblUserSaves");

            migrationBuilder.DropTable(
                name: "tblCategory");

            migrationBuilder.DropTable(
                name: "tblImages");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblLocation",
                schema: "dim");
        }
    }
}
