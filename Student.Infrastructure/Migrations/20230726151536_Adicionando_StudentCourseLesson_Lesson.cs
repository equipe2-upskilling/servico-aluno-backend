using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Student.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adicionando_StudentCourseLesson_Lesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Grade",
                table: "StudentsCourses",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "StudentsCourses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UrlRepository",
                table: "StudentsCourses",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Enrollmentstatusid",
                table: "Courses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Courses",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "Courses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Enrollmentstatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollmentstatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseId1 = table.Column<int>(type: "integer", nullable: true),
                    TitleLesson = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DescriptionLesson = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DurationLesson = table.Column<int>(type: "integer", nullable: false),
                    VideoLesson = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonId);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_CourseId1",
                        column: x => x.CourseId1,
                        principalTable: "Courses",
                        principalColumn: "CourseId");
                });

            migrationBuilder.CreateTable(
                name: "StudentCourseLessons",
                columns: table => new
                {
                    StudentCourseLessonId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonId1 = table.Column<int>(type: "integer", nullable: true),
                    CourseId1 = table.Column<int>(type: "integer", nullable: true),
                    StudentenId1 = table.Column<int>(type: "integer", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseLessons", x => x.StudentCourseLessonId);
                    table.ForeignKey(
                        name: "FK_StudentCourseLessons_Courses_CourseId1",
                        column: x => x.CourseId1,
                        principalTable: "Courses",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_StudentCourseLessons_Lessons_LessonId1",
                        column: x => x.LessonId1,
                        principalTable: "Lessons",
                        principalColumn: "LessonId");
                    table.ForeignKey(
                        name: "FK_StudentCourseLessons_Students_StudentenId1",
                        column: x => x.StudentenId1,
                        principalTable: "Students",
                        principalColumn: "StudentenId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Enrollmentstatusid",
                table: "Courses",
                column: "Enrollmentstatusid");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseId1",
                table: "Lessons",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseLessons_CourseId1",
                table: "StudentCourseLessons",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseLessons_LessonId1",
                table: "StudentCourseLessons",
                column: "LessonId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseLessons_StudentenId1",
                table: "StudentCourseLessons",
                column: "StudentenId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Enrollmentstatus_Enrollmentstatusid",
                table: "Courses",
                column: "Enrollmentstatusid",
                principalTable: "Enrollmentstatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Enrollmentstatus_Enrollmentstatusid",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Enrollmentstatus");

            migrationBuilder.DropTable(
                name: "StudentCourseLessons");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Enrollmentstatusid",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "StudentsCourses");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "StudentsCourses");

            migrationBuilder.DropColumn(
                name: "UrlRepository",
                table: "StudentsCourses");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Enrollmentstatusid",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "Courses");
        }
    }
}
