using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_TinhNguyen.Migrations
{
    /// <inheritdoc />
    public partial class AddModuleGayQuy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CauHinhGayQuy",
                columns: table => new
                {
                    IDCauHinhGQ = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDChienDich = table.Column<int>(type: "int", nullable: false),
                    FontTieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontNoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauChuDao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_Nhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_MauChuNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_MauNenNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_MauTieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_CoChuTieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_MauMoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_TextNut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_LinkNut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_MauNutStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_MauNutEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_LinkAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_MauNenStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_MauNenMid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_MauNenEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DongGop_Nhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DongGop_TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DongGop_MauTieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DongGop_MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DongGop_MauMoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DongGop_GhiChuChanTrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaoCao_MauNen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaoCao_Nhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaoCao_TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaoCao_MauTieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaoCao_MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaoCao_MauMoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaoCao_TextNut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaoCao_LinkNut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiTro_Nhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiTro_TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiTro_TieuDeNoiBat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiTro_MauTieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiTro_MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHinhGayQuy", x => x.IDCauHinhGQ);
                    table.ForeignKey(
                        name: "FK_CauHinhGayQuy_ChienDich_IDChienDich",
                        column: x => x.IDChienDich,
                        principalTable: "ChienDich",
                        principalColumn: "IDChienDich",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KenhDongGop",
                columns: table => new
                {
                    IDKenh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCauHinhGQ = table.Column<int>(type: "int", nullable: false),
                    TenKenh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauNenIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauTieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauMoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauNenCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextNut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiHanhDong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkNgoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAnhQR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNganHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenChuTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungChuyenKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChuThem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KenhDongGop", x => x.IDKenh);
                    table.ForeignKey(
                        name: "FK_KenhDongGop_CauHinhGayQuy_IDCauHinhGQ",
                        column: x => x.IDCauHinhGQ,
                        principalTable: "CauHinhGayQuy",
                        principalColumn: "IDCauHinhGQ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhaTaiTroGayQuy",
                columns: table => new
                {
                    IDNhaTaiTroGQ = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCauHinhGQ = table.Column<int>(type: "int", nullable: false),
                    NhomTaiTro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDonVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiThieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaTaiTroGayQuy", x => x.IDNhaTaiTroGQ);
                    table.ForeignKey(
                        name: "FK_NhaTaiTroGayQuy_CauHinhGayQuy_IDCauHinhGQ",
                        column: x => x.IDCauHinhGQ,
                        principalTable: "CauHinhGayQuy",
                        principalColumn: "IDCauHinhGQ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CauHinhGayQuy_IDChienDich",
                table: "CauHinhGayQuy",
                column: "IDChienDich");

            migrationBuilder.CreateIndex(
                name: "IX_KenhDongGop_IDCauHinhGQ",
                table: "KenhDongGop",
                column: "IDCauHinhGQ");

            migrationBuilder.CreateIndex(
                name: "IX_NhaTaiTroGayQuy_IDCauHinhGQ",
                table: "NhaTaiTroGayQuy",
                column: "IDCauHinhGQ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KenhDongGop");

            migrationBuilder.DropTable(
                name: "NhaTaiTroGayQuy");

            migrationBuilder.DropTable(
                name: "CauHinhGayQuy");
        }
    }
}
