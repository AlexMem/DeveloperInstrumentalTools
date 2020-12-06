using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.EFCore.Migrations
{
    public partial class DateToTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Weather",
                newName: "TimeStamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Weather",
                newName: "Date");
        }
    }
}
