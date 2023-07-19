using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class addroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b105690-20d0-4e28-b181-eedf365d1747", "1", "Admin", "Admin" },
                    { "2ebf67f3-c9e1-4eb2-b94c-86f199af71f3", "3", "HR", "HR" },
                    { "5bf81208-28c1-4bd6-add8-ecd5d06d9b87", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b105690-20d0-4e28-b181-eedf365d1747");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ebf67f3-c9e1-4eb2-b94c-86f199af71f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bf81208-28c1-4bd6-add8-ecd5d06d9b87");
        }
    }
}
