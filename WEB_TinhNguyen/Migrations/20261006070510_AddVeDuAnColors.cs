using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_TinhNguyen.Migrations
{
    /// <inheritdoc />
    public partial class AddVeDuAnColors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VeDuAn_MauChu",
                table: "CauHinhTrangChu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VeDuAn_MauNenTag",
                table: "CauHinhTrangChu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VeDuAn_MauTieuDe",
                table: "CauHinhTrangChu",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VeDuAn_MauChu",
                table: "CauHinhTrangChu");

            migrationBuilder.DropColumn(
                name: "VeDuAn_MauNenTag",
                table: "CauHinhTrangChu");

            migrationBuilder.DropColumn(
                name: "VeDuAn_MauTieuDe",
                table: "CauHinhTrangChu");
        }
    }
}
