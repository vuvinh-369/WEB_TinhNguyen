using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_TinhNguyen.Migrations
{
    /// <inheritdoc />
    public partial class AddKyUcModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CauHinhKyUc",
                columns: table => new
                {
                    IDCauHinhKyUc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDChienDich = table.Column<int>(type: "int", nullable: false),
                    TieuDeChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoanVanMoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungTongKetHtml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAnhBia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauChuDao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauNenHienTai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontTieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHinhKyUc", x => x.IDCauHinhKyUc);
                    table.ForeignKey(
                        name: "FK_CauHinhKyUc_ChienDich_IDChienDich",
                        column: x => x.IDChienDich,
                        principalTable: "ChienDich",
                        principalColumn: "IDChienDich",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnhKyUc",
                columns: table => new
                {
                    IDAnh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCauHinhKyUc = table.Column<int>(type: "int", nullable: false),
                    LinkAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuDeAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaAnhDoc = table.Column<bool>(type: "bit", nullable: false),
                    ThuTu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnhKyUc", x => x.IDAnh);
                    table.ForeignKey(
                        name: "FK_AnhKyUc_CauHinhKyUc_IDCauHinhKyUc",
                        column: x => x.IDCauHinhKyUc,
                        principalTable: "CauHinhKyUc",
                        principalColumn: "IDCauHinhKyUc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhaTaiTroKyUc",
                columns: table => new
                {
                    IDNhaTaiTro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCauHinhKyUc = table.Column<int>(type: "int", nullable: false),
                    TenDonVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhanLoai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaTaiTroKyUc", x => x.IDNhaTaiTro);
                    table.ForeignKey(
                        name: "FK_NhaTaiTroKyUc_CauHinhKyUc_IDCauHinhKyUc",
                        column: x => x.IDCauHinhKyUc,
                        principalTable: "CauHinhKyUc",
                        principalColumn: "IDCauHinhKyUc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnhKyUc_IDCauHinhKyUc",
                table: "AnhKyUc",
                column: "IDCauHinhKyUc");

            migrationBuilder.CreateIndex(
                name: "IX_CauHinhKyUc_IDChienDich",
                table: "CauHinhKyUc",
                column: "IDChienDich");

            migrationBuilder.CreateIndex(
                name: "IX_NhaTaiTroKyUc_IDCauHinhKyUc",
                table: "NhaTaiTroKyUc",
                column: "IDCauHinhKyUc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnhKyUc");

            migrationBuilder.DropTable(
                name: "NhaTaiTroKyUc");

            migrationBuilder.DropTable(
                name: "CauHinhKyUc");
        }
    }
}
