using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_TinhNguyen.Migrations
{
    /// <inheritdoc />
    public partial class AddHieuUng : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDHieuUng",
                table: "CauHinhTrangChu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ThuVienHieuUng",
                columns: table => new
                {
                    IDHieuUng = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHieuUng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkFileJS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuVienHieuUng", x => x.IDHieuUng);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CauHinhTrangChu_IDHieuUng",
                table: "CauHinhTrangChu",
                column: "IDHieuUng");

            migrationBuilder.AddForeignKey(
                name: "FK_CauHinhTrangChu_ThuVienHieuUng_IDHieuUng",
                table: "CauHinhTrangChu",
                column: "IDHieuUng",
                principalTable: "ThuVienHieuUng",
                principalColumn: "IDHieuUng");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CauHinhTrangChu_ThuVienHieuUng_IDHieuUng",
                table: "CauHinhTrangChu");

            migrationBuilder.DropTable(
                name: "ThuVienHieuUng");

            migrationBuilder.DropIndex(
                name: "IX_CauHinhTrangChu_IDHieuUng",
                table: "CauHinhTrangChu");

            migrationBuilder.DropColumn(
                name: "IDHieuUng",
                table: "CauHinhTrangChu");
        }
    }
}
