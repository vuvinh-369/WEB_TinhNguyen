using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_TinhNguyen.Migrations
{
    /// <inheritdoc />
    public partial class AddModuleBanToChuc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CauHinhBanToChuc",
                columns: table => new
                {
                    IDCauHinhBTC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDChienDich = table.Column<int>(type: "int", nullable: false),
                    FontTieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontNoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauNenStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauNenMid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauNenEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HienThiBanSangLap = table.Column<bool>(type: "bit", nullable: false),
                    SangLap_Nhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SangLap_TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SangLap_MauTieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SangLap_CoChuTieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HienThiSoDoToChuc = table.Column<bool>(type: "bit", nullable: false),
                    SoDo_Nhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDo_TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDo_MauTieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDo_DoanVanMoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDo_MauDuongKe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HienThiDanhSachBTC = table.Column<bool>(type: "bit", nullable: false),
                    BTC_Nhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BTC_TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BTC_MauTieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuongHienThiBanDau = table.Column<int>(type: "int", nullable: false),
                    CTA_MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CTA_TextNut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CTA_LinkNut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CTA_MauNutStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CTA_MauNutEnd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHinhBanToChuc", x => x.IDCauHinhBTC);
                    table.ForeignKey(
                        name: "FK_CauHinhBanToChuc_ChienDich_IDChienDich",
                        column: x => x.IDChienDich,
                        principalTable: "ChienDich",
                        principalColumn: "IDChienDich",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThanhVienBanToChuc",
                columns: table => new
                {
                    IDThanhVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCauHinhBTC = table.Column<int>(type: "int", nullable: false),
                    NhomHienThi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucVuChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViCongTac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucVuPhu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTaChiTiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkFacebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoHuyHieuSao = table.Column<bool>(type: "bit", nullable: false),
                    MauChuDaoThe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauNenThe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhVienBanToChuc", x => x.IDThanhVien);
                    table.ForeignKey(
                        name: "FK_ThanhVienBanToChuc_CauHinhBanToChuc_IDCauHinhBTC",
                        column: x => x.IDCauHinhBTC,
                        principalTable: "CauHinhBanToChuc",
                        principalColumn: "IDCauHinhBTC",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CauHinhBanToChuc_IDChienDich",
                table: "CauHinhBanToChuc",
                column: "IDChienDich");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVienBanToChuc_IDCauHinhBTC",
                table: "ThanhVienBanToChuc",
                column: "IDCauHinhBTC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThanhVienBanToChuc");

            migrationBuilder.DropTable(
                name: "CauHinhBanToChuc");
        }
    }
}
