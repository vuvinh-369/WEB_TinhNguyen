using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_TinhNguyen.Migrations
{
    /// <inheritdoc />
    public partial class AddChuongTrinhDemNguoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChuongTrinhDemNguoc",
                columns: table => new
                {
                    IDChuongTrinh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCauHinh = table.Column<int>(type: "int", nullable: false),
                    TieuDePhu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuDeChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianHienThi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MauNenStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauNenEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpKetThuc = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuongTrinhDemNguoc", x => x.IDChuongTrinh);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhDemNguoc_CauHinhTrangChu_IDCauHinh",
                        column: x => x.IDCauHinh,
                        principalTable: "CauHinhTrangChu",
                        principalColumn: "IDCauHinh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhDemNguoc_IDCauHinh",
                table: "ChuongTrinhDemNguoc",
                column: "IDCauHinh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChuongTrinhDemNguoc");
        }
    }
}
