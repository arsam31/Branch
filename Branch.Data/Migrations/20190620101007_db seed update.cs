using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Branch.Data.Migrations
{
    public partial class dbseedupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ApproveDate", "DOB", "Email", "FirstName", "IsActive", "IsApproved", "LastName", "Mobile", "ModifiedDate", "Modifiedby", "Password", "Remarks", "Role", "Status", "UserName" },
                values: new object[] { 1L, new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "uncle.bob@gmail.com", "Uncle", true, true, "Bob", "0404000", new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 12L, "1234", "dsd", "admin", 12, "softwareallianc" });
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
