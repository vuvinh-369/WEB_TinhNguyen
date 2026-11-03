using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_TinhNguyen.Migrations
{
    /// <inheritdoc />
    public partial class AddModuleTinTuc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CauHinhTinTuc",
                columns: table => new
                {
                    IDCauHinhTT = table.Column<int>(type: "int", nullable: false)
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
                    Hero_MauNenStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_MauNenMid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hero_MauNenEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanhSach_MauNenStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanhSach_MauNenEnd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHinhTinTuc", x => x.IDCauHinhTT);
                    table.ForeignKey(
                        name: "FK_CauHinhTinTuc_ChienDich_IDChienDich",
                        column: x => x.IDChienDich,
                        principalTable: "ChienDich",
                        principalColumn: "IDChienDich",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaiVietTinTuc",
                columns: table => new
                {
                    IDBaiViet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCauHinhTT = table.Column<int>(type: "int", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThePhanLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauNenTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauChuTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrichDan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungChiTiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAnhTrongBai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkBaiVietGoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauTieuDeThe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauTieuDePopup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoChuTieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuotThich = table.Column<int>(type: "int", nullable: false),
                    NgayDang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiVietTinTuc", x => x.IDBaiViet);
                    table.ForeignKey(
                        name: "FK_BaiVietTinTuc_CauHinhTinTuc_IDCauHinhTT",
                        column: x => x.IDCauHinhTT,
                        principalTable: "CauHinhTinTuc",
                        principalColumn: "IDCauHinhTT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiVietTinTuc_IDCauHinhTT",
                table: "BaiVietTinTuc",
                column: "IDCauHinhTT");

            migrationBuilder.CreateIndex(
                name: "IX_CauHinhTinTuc_IDChienDich",
                table: "CauHinhTinTuc",
                column: "IDChienDich");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaiVietTinTuc");

            migrationBuilder.DropTable(
                name: "CauHinhTinTuc");
        }
    }
}
