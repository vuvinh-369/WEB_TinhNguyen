using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_TinhNguyen.Migrations
{
    /// <inheritdoc />
    public partial class AddBannerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. CHỈ THÊM CỘT TỐC ĐỘ VÀO BẢNG ĐÃ CÓ
            migrationBuilder.AddColumn<int>(
                name: "TocDoChuyenSlide",
                table: "CauHinhTrangChu",
                type: "int",
                nullable: false,
                defaultValue: 4000);

            // 2. CHỈ TẠO BẢNG BANNER MỚI
            migrationBuilder.CreateTable(
                name: "BannerTrangChu",
                columns: table => new
                {
                    IDBanner = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCauHinh = table.Column<int>(type: "int", nullable: false),
                    LinkAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuDeAlt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerTrangChu", x => x.IDBanner);
                    table.ForeignKey(
                        name: "FK_BannerTrangChu_CauHinhTrangChu_IDCauHinh",
                        column: x => x.IDCauHinh,
                        principalTable: "CauHinhTrangChu",
                        principalColumn: "IDCauHinh",
                        onDelete: ReferentialAction.Cascade);
                });

            // 3. TẠO INDEX CHO BẢNG MỚI
            migrationBuilder.CreateIndex(
                name: "IX_BannerTrangChu_IDCauHinh",
                table: "BannerTrangChu",
                column: "IDCauHinh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // KHI ROLLBACK CHỈ XÓA NHỮNG GÌ VỪA THÊM Ở TRÊN
            migrationBuilder.DropTable(
                name: "BannerTrangChu");

            migrationBuilder.DropColumn(
                name: "TocDoChuyenSlide",
                table: "CauHinhTrangChu");
        }
    }
}