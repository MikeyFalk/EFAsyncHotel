using Microsoft.EntityFrameworkCore.Migrations;

namespace EFAsyncHotel.Migrations
{
    public partial class seedhotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "City", "Name", "PhoneNumber", "State" },
                values: new object[] { 1, null, null, "Grand Pacific", null, null });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "City", "Name", "PhoneNumber", "State" },
                values: new object[] { 2, null, null, "Mountain View", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
