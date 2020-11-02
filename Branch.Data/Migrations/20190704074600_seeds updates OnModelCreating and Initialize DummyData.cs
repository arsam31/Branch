using Microsoft.EntityFrameworkCore.Migrations;

namespace Branch.Data.Migrations
{
    public partial class seedsupdatesOnModelCreatingandInitializeDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Email", "FirstName", "LastName", "Mobile", "Modifiedby", "Remarks", "Status", "UserName" },
                values: new object[] { "arsamrahmaan31@gmail.com", "Arsam", "Rahmaan", "03367065720", 2L, "Awesome", 1, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Email", "FirstName", "LastName", "Mobile", "Modifiedby", "Remarks", "Status", "UserName" },
                values: new object[] { "uncle.bob@gmail.com", "Uncle", "Bob", "0404000", 12L, "dsd", 12, "softwareallianc" });
        }
    }
}
