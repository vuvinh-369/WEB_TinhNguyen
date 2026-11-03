using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_TinhNguyen.Migrations
{
    /// <inheritdoc />
    public partial class AddMascot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HienThiMascot",
                table: "CauHinhTrangChu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LinkAnhMascot",
                table: "CauHinhTrangChu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ViTriMascot",
                table: "CauHinhTrangChu",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HienThiMascot",
                table: "CauHinhTrangChu");

            migrationBuilder.DropColumn(
                name: "LinkAnhMascot",
                table: "CauHinhTrangChu");

            migrationBuilder.DropColumn(
                name: "ViTriMascot",
                table: "CauHinhTrangChu");
        }
    }
}
