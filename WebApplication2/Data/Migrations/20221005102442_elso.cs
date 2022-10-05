using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Data.Migrations
{
    public partial class elso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinimumOraber",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Allasok",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Vallalat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Megnevezes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oraber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allasok", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "AllasSiteUser",
                columns: table => new
                {
                    AllasokUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JelentkezokId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllasSiteUser", x => new { x.AllasokUID, x.JelentkezokId });
                    table.ForeignKey(
                        name: "FK_AllasSiteUser_Allasok_AllasokUID",
                        column: x => x.AllasokUID,
                        principalTable: "Allasok",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllasSiteUser_AspNetUsers_JelentkezokId",
                        column: x => x.JelentkezokId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllasSiteUser_JelentkezokId",
                table: "AllasSiteUser",
                column: "JelentkezokId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllasSiteUser");

            migrationBuilder.DropTable(
                name: "Allasok");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MinimumOraber",
                table: "AspNetUsers");
        }
    }
}
