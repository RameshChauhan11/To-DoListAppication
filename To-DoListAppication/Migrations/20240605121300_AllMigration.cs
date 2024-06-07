using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_DoListAppication.Migrations
{
    public partial class AllMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "signInModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    mobile = table.Column<long>(type: "bigint", nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_signInModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "workRecordModels",
                columns: table => new
                {
                    workId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    workName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    workDetails = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsCompleted = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    dateOfWork = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workRecordModels", x => x.workId);
                });

            migrationBuilder.InsertData(
                table: "signInModels",
                columns: new[] { "Id", "email", "mobile", "name", "password" },
                values: new object[] { 1, "ch@gmail.com", 6574837373L, "ramesh", "111" });

            migrationBuilder.InsertData(
                table: "workRecordModels",
                columns: new[] { "workId", "IsCompleted", "dateOfWork", "userEmail", "workDetails", "workName" },
                values: new object[] { 1, "Yes", new DateTime(2024, 6, 5, 17, 42, 59, 818, DateTimeKind.Local).AddTicks(3001), "ch@gmail.com", "Add  model folder. add a class", "tocreate model" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "signInModels");

            migrationBuilder.DropTable(
                name: "workRecordModels");
        }
    }
}
