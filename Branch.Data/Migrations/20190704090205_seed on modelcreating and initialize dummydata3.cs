using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Branch.Data.Migrations
{
    public partial class seedonmodelcreatingandinitializedummydata3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ApproveDate", "DOB", "Email", "FirstName", "IsActive", "IsApproved", "LastName", "Mobile", "ModifiedDate", "Modifiedby", "Password", "Remarks", "Role", "Status", "UserName" },
                values: new object[] { 2L, new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "arsamrahmaan31@gmail.com", "Arsam", true, true, "Rahmaan", "03367065720", new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "1234", "Awesome", "admin", 1, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ApproveDate", "DOB", "Email", "FirstName", "IsActive", "IsApproved", "LastName", "Mobile", "ModifiedDate", "Modifiedby", "Password", "Remarks", "Role", "Status", "UserName" },
                values: new object[] { 1L, new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "arsamrahmaan31@gmail.com", "Arsam", true, true, "Rahmaan", "03367065720", new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "1234", "Awesome", "admin", 1, "admin" });
        }
    }
}
