using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Branch.Data.Migrations
{
    public partial class seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ApproveDate", "DOB", "Email", "FirstName", "IsActive", "IsApproved", "LastName", "Mobile", "ModifiedDate", "Modifiedby", "Password", "Remarks", "Role", "Status", "UserName" },
                values: new object[] { 1L, new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "softwareAlliance@gmail.com", "Software", true, true, "Alliance", "03000000000", new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 42L, "softwarealliance", "abc", "admin", 1, "softwarealliance" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
