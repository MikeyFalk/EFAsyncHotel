using Microsoft.EntityFrameworkCore.Migrations;

namespace EFAsyncHotel.Migrations
{
    public partial class addSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Amenities",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Microwave" },
                    { 2, "Mini Bar" },
                    { 3, "A / C" }
                });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "City", "State" },
                values: new object[] { "123 42nd Ave", "San Francisco", "CA" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "State" },
                values: new object[] { "5678 Rockies Rd", "Denver", "CO" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "City", "Name", "PhoneNumber", "State" },
                values: new object[] { 3, "9283 Lakeview Ln", "Tahoe City", "Lake Side", null, "CA" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Snore Fest" },
                    { 2, 2, "Sir Snooze Alot" },
                    { 3, 3, "Shut Eye" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Amenities",
                newName: "ID");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "City", "State" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "State" },
                values: new object[] { null, null, null });
        }
    }
}
