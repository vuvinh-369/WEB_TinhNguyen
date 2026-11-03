using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_TinhNguyen.Migrations
{
    /// <inheritdoc />
    public partial class FixLoTrinh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoiDungLoTrinhHtml",
                table: "ChangChuongTrinh");

            migrationBuilder.CreateTable(
                name: "ChiTietLoTrinh",
                columns: table => new
                {
                    IDLoTrinh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDChang = table.Column<int>(type: "int", nullable: false),
                    ThoiGian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungHoatDong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietLoTrinh", x => x.IDLoTrinh);
                    table.ForeignKey(
                        name: "FK_ChiTietLoTrinh_ChangChuongTrinh_IDChang",
                        column: x => x.IDChang,
                        principalTable: "ChangChuongTrinh",
                        principalColumn: "IDChang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietLoTrinh_IDChang",
                table: "ChiTietLoTrinh",
                column: "IDChang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietLoTrinh");

            migrationBuilder.AddColumn<string>(
                name: "NoiDungLoTrinhHtml",
                table: "ChangChuongTrinh",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
