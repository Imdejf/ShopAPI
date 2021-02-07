using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.DataAccess.Migrations
{
    public partial class FixInDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PickUpName",
                table: "OrderHeader",
                newName: "PickupName");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "OrderHeader",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TransactionId",
                table: "OrderHeader",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "OrderHeader");

            migrationBuilder.RenameColumn(
                name: "PickupName",
                table: "OrderHeader",
                newName: "PickUpName");
        }
    }
}
