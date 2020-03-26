using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TasksWebApp.Migrations
{
    public partial class add_zoom_meeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZoomMeetings",
                columns: table => new
                {
                    ZoomMeetingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CourseName = table.Column<string>(nullable: true),
                    ProfessorName = table.Column<string>(nullable: true),
                    MeetingId = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoomMeetings", x => x.ZoomMeetingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZoomMeetings");
        }
    }
}
