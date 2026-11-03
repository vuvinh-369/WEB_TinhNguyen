using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_TinhNguyen.Migrations
{
    /// <inheritdoc />
    public partial class AddTinTucDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KichCoTieuDe",
                table: "TinTucTrangChu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MauTieuDe",
                table: "TinTucTrangChu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoiDungChiTiet",
                table: "TinTucTrangChu",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KichCoTieuDe",
                table: "TinTucTrangChu");

            migrationBuilder.DropColumn(
                name: "MauTieuDe",
                table: "TinTucTrangChu");

            migrationBuilder.DropColumn(
                name: "NoiDungChiTiet",
                table: "TinTucTrangChu");
        }
    }
}
