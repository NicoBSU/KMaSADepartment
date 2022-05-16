using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KMaSA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserReworkMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "students");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "students");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "students");

            migrationBuilder.DropColumn(
                name: "middle_name",
                table: "students");

            migrationBuilder.DropColumn(
                name: "picture_link",
                table: "students");

            migrationBuilder.DropColumn(
                name: "birth_date",
                table: "mentors");

            migrationBuilder.DropColumn(
                name: "email",
                table: "mentors");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "mentors");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "mentors");

            migrationBuilder.DropColumn(
                name: "middle_name",
                table: "mentors");

            migrationBuilder.DropColumn(
                name: "picture_link",
                table: "mentors");

            migrationBuilder.RenameTable(
                name: "study_resources",
                newName: "studyResources");

            migrationBuilder.RenameTable(
                name: "course_works",
                newName: "courseWorks");

            migrationBuilder.RenameTable(
                name: "blog_articles",
                newName: "blogArticles");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "mentors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "AspNetUsers",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "AspNetUsers",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "middle_name",
                table: "AspNetUsers",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "photo_url",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "user_type",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_students_user_id",
                table: "students",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_mentors_user_id",
                table: "mentors",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_mentors_users_user_id",
                table: "mentors",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_students_users_user_id",
                table: "students",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mentors_users_user_id",
                table: "mentors");

            migrationBuilder.DropForeignKey(
                name: "fk_students_users_user_id",
                table: "students");

            migrationBuilder.DropIndex(
                name: "ix_students_user_id",
                table: "students");

            migrationBuilder.DropIndex(
                name: "ix_mentors_user_id",
                table: "mentors");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "students");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "mentors");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "middle_name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "photo_url",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "user_type",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "studyResources",
                newName: "study_resources");

            migrationBuilder.RenameTable(
                name: "courseWorks",
                newName: "course_works");

            migrationBuilder.RenameTable(
                name: "blogArticles",
                newName: "blog_articles");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "students",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "students",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "students",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "middle_name",
                table: "students",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "picture_link",
                table: "students",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "birth_date",
                table: "mentors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "mentors",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "mentors",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "mentors",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "middle_name",
                table: "mentors",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "picture_link",
                table: "mentors",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }
    }
}
