using Microsoft.EntityFrameworkCore.Migrations;

namespace re_jos1.api.vs1.Migrations
{
    public partial class AddVolumeToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VolumeInMl",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VolumeInMl",
                table: "Products");
        }
    }
}
