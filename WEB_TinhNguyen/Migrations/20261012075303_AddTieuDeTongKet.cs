using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_TinhNguyen.Migrations
{
    /// <inheritdoc />
    public partial class AddTieuDeTongKet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FontTieuDeTongKet",
                table: "CauHinhKyUc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MauTieuDeTongKet",
                table: "CauHinhKyUc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TieuDeTongKet",
                table: "CauHinhKyUc",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FontTieuDeTongKet",
                table: "CauHinhKyUc");

            migrationBuilder.DropColumn(
                name: "MauTieuDeTongKet",
                table: "CauHinhKyUc");

            migrationBuilder.DropColumn(
                name: "TieuDeTongKet",
                table: "CauHinhKyUc");
        }
    }
}
