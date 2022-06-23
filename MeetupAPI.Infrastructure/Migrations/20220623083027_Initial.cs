using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetupAPI.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meetups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Plan = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Speaker = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MeetupTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MeetupPlace = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    PasswordHash = table.Column<string>(type: "char(60)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Meetups",
                columns: new[] { "Id", "CreatedDate", "Creator", "Description", "MeetupPlace", "MeetupTime", "ModifiedDate", "Name", "Plan", "Speaker" },
                values: new object[] { 1, null, "Alex Inkin", "We will talk about Angular!", "medium.com", new DateTimeOffset(new DateTime(2022, 6, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Angular Developement", "1. Angular 2. DI", "Alex Inkin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Login", "ModifiedDate", "PasswordHash", "Role" },
                values: new object[] { 1, null, "admin", null, "$2a$11$ryrrT9gOJR0ySA5NsIlZJOUNcBSFpQQGEYWL5rlOpNKkipsWpvyea", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meetups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
