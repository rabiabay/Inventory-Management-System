using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StokYonetimSistemi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveYetkiTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Yetki");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Yetki",
                columns: table => new
                {
                    YetkiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolID = table.Column<int>(type: "int", nullable: false),
                    TabloAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    YetkiTuru = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yetki", x => x.YetkiID);
                    table.ForeignKey(
                        name: "FK_Yetki_Rol_RolID",
                        column: x => x.RolID,
                        principalTable: "Rol",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Yetki_RolID",
                table: "Yetki",
                column: "RolID");
        }
    }
}
