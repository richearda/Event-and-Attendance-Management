using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETMS_API.Migrations
{
    /// <inheritdoc />
    public partial class AddcolumnstotableAspNetUsersandAttendees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_AspNetUsers_UserId",
                table: "Attendees");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOutTime",
                table: "Attendees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_AspNetUsers_UserId",
                table: "Attendees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_AspNetUsers_UserId",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "CheckOutTime",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_AspNetUsers_UserId",
                table: "Attendees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
