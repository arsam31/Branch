using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Branch.Data.Migrations
{
    public partial class UsersSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DOB", "Email", "FirstName", "IsActive", "LastName", "Mobile", "ModifiedDate", "Modifiedby", "Password", "Remarks", "Status", "UserName" },
                values: new object[] { 13L, new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "uncle.bob@gmail.com", "Uncle", true, "Bob", "0443434", new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1213L, "1233", "dsadsd", 12, "asdsa" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DOB", "Email", "FirstName", "IsActive", "LastName", "Mobile", "ModifiedDate", "Modifiedby", "Password", "Remarks", "Status", "UserName" },
                values: new object[] { 11L, new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "uncle.bfdsfdob@gmail.com", "fdsfdsf", true, "Bofdsfdsb", "0443434", new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1213L, "1233", "dsadsd", 12, "asdsa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13L);
        }
    }
}
