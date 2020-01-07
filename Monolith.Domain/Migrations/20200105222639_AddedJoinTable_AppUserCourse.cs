using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Monolith.Domain.Migrations
{
    public partial class AddedJoinTable_AppUserCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appuser",
                columns: table => new
                {
                    userid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    firstname = table.Column<string>(maxLength: 255, nullable: true),
                    lastname = table.Column<string>(maxLength: 255, nullable: true),
                    email = table.Column<string>(maxLength: 255, nullable: true),
                    password = table.Column<string>(maxLength: 255, nullable: true),
                    instructorrating = table.Column<int>(nullable: true),
                    salt = table.Column<string>(maxLength: 128, nullable: true),
                    isapproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("appuser_pkey", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    courseid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    coursename = table.Column<string>(maxLength: 255, nullable: true),
                    coursedescription = table.Column<string>(nullable: true),
                    rating = table.Column<int>(nullable: true),
                    instructorid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.courseid);
                    table.ForeignKey(
                        name: "course_instructorid_fkey",
                        column: x => x.instructorid,
                        principalTable: "appuser",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserCourse",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserCourse", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_AppUserCourse_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "course",
                        principalColumn: "courseid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserCourse_appuser_UserId",
                        column: x => x.UserId,
                        principalTable: "appuser",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "topic",
                columns: table => new
                {
                    topicid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    courseid = table.Column<int>(nullable: false),
                    topicname = table.Column<string>(maxLength: 255, nullable: true),
                    topicdescription = table.Column<string>(maxLength: 500, nullable: true),
                    createdon = table.Column<DateTime>(nullable: true),
                    topicorder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topic", x => x.topicid);
                    table.ForeignKey(
                        name: "topic_courseid_fkey",
                        column: x => x.courseid,
                        principalTable: "course",
                        principalColumn: "courseid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lecture",
                columns: table => new
                {
                    lectureid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    topicid = table.Column<int>(nullable: false),
                    lecturename = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lecture", x => x.lectureid);
                    table.ForeignKey(
                        name: "lecture_topicid_fkey",
                        column: x => x.topicid,
                        principalTable: "topic",
                        principalColumn: "topicid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserCourse_CourseId",
                table: "AppUserCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_course_instructorid",
                table: "course",
                column: "instructorid");

            migrationBuilder.CreateIndex(
                name: "IX_lecture_topicid",
                table: "lecture",
                column: "topicid");

            migrationBuilder.CreateIndex(
                name: "IX_topic_courseid",
                table: "topic",
                column: "courseid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserCourse");

            migrationBuilder.DropTable(
                name: "lecture");

            migrationBuilder.DropTable(
                name: "topic");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "appuser");
        }
    }
}
