using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentitySampleApi.DataAccessLayer.Migrations
{
    public partial class Removedrolepropertyfromuseridentityentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
