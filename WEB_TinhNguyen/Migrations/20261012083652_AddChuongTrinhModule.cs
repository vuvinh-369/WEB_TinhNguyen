using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_TinhNguyen.Migrations
{
    /// <inheritdoc />
    public partial class AddChuongTrinhModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CauHinhChuongTrinh",
                columns: table => new
                {
                    IDCauHinhCT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDChienDich = table.Column<int>(type: "int", nullable: false),
                    TieuDeChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuDeNhanManh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoanVanMoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAnhHero1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAnhHero2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauChuDao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauNenHienTai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontTieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHinhChuongTrinh", x => x.IDCauHinhCT);
                    table.ForeignKey(
                        name: "FK_CauHinhChuongTrinh_ChienDich_IDChienDich",
                        column: x => x.IDChienDich,
                        principalTable: "ChienDich",
                        principalColumn: "IDChienDich",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChangChuongTrinh",
                columns: table => new
                {
                    IDChang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCauHinhCT = table.Column<int>(type: "int", nullable: false),
                    NhanThoiGian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuDeChang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTaChang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungLoTrinhHtml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangChuongTrinh", x => x.IDChang);
                    table.ForeignKey(
                        name: "FK_ChangChuongTrinh_CauHinhChuongTrinh_IDCauHinhCT",
                        column: x => x.IDCauHinhCT,
                        principalTable: "CauHinhChuongTrinh",
                        principalColumn: "IDCauHinhCT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CauHinhChuongTrinh_IDChienDich",
                table: "CauHinhChuongTrinh",
                column: "IDChienDich");

            migrationBuilder.CreateIndex(
                name: "IX_ChangChuongTrinh_IDCauHinhCT",
                table: "ChangChuongTrinh",
                column: "IDCauHinhCT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangChuongTrinh");

            migrationBuilder.DropTable(
                name: "CauHinhChuongTrinh");
        }
    }
}
