using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProniaMVCFull.Migrations
{
    /// <inheritdoc />
    public partial class AddedTagIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TagIds",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagIds",
                table: "Products");
        }
    }
}
