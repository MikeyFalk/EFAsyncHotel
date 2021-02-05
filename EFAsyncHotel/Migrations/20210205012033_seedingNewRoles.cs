using Microsoft.EntityFrameworkCore.Migrations;

namespace EFAsyncHotel.Migrations
{
    public partial class seedingNewRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "district manager", "00000000-0000-0000-0000-000000000000", "District Manager", "DISTRICT MANAGER" },
                    { "property manager", "00000000-0000-0000-0000-000000000000", "Property Manager", "PROPERTY MANAGER" },
                    { "agent", "00000000-0000-0000-0000-000000000000", "Agent", "AGENT" },
                    { "guest user", "00000000-0000-0000-0000-000000000000", "Guest User", "GUEST USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "agent");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "district manager");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "guest user");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "property manager");
        }
    }
}
