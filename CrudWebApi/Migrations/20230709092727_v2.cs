using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "inStock" },
                values: new object[] { new Guid("57b7903c-fcab-42a0-b3b6-685396866d57"), "Mekanik Klavye", "Razer Blackwidow", 1800m, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("57b7903c-fcab-42a0-b3b6-685396866d57"));
        }
    }
}
