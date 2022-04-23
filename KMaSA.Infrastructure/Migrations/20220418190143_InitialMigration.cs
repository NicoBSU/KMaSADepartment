﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KMaSA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blog_articles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    publication_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    content = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    pictures_links = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_blog_articles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mentors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    biography = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    picture_link = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mentors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "study_resources",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    link = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_study_resources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    rating = table.Column<double>(type: "float", nullable: true),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    picture_link = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_students", x => x.id);
                    table.ForeignKey(
                        name: "fk_students_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mentor_entity_study_resource_entity",
                columns: table => new
                {
                    publications_id = table.Column<int>(type: "int", nullable: false),
                    tagged_mentors_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mentor_entity_study_resource_entity", x => new { x.publications_id, x.tagged_mentors_id });
                    table.ForeignKey(
                        name: "fk_mentor_entity_study_resource_entity_mentors_tagged_mentors_id",
                        column: x => x.tagged_mentors_id,
                        principalTable: "mentors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_mentor_entity_study_resource_entity_study_resources_publications_id",
                        column: x => x.publications_id,
                        principalTable: "study_resources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "course_works",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mentor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_course_works", x => x.id);
                    table.ForeignKey(
                        name: "fk_course_works_mentors_mentor_id",
                        column: x => x.mentor_id,
                        principalTable: "mentors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_course_works_students_student_id",
                        column: x => x.student_id,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    picture_link = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    student_entity_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subjects", x => x.id);
                    table.ForeignKey(
                        name: "fk_subjects_students_student_entity_id",
                        column: x => x.student_entity_id,
                        principalTable: "students",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "mentor_entity_subject_entity",
                columns: table => new
                {
                    mentors_id = table.Column<int>(type: "int", nullable: false),
                    subjects_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mentor_entity_subject_entity", x => new { x.mentors_id, x.subjects_id });
                    table.ForeignKey(
                        name: "fk_mentor_entity_subject_entity_mentors_mentors_id",
                        column: x => x.mentors_id,
                        principalTable: "mentors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_mentor_entity_subject_entity_subjects_subjects_id",
                        column: x => x.subjects_id,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "study_resource_entity_subject_entity",
                columns: table => new
                {
                    literature_id = table.Column<int>(type: "int", nullable: false),
                    subjects_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_study_resource_entity_subject_entity", x => new { x.literature_id, x.subjects_id });
                    table.ForeignKey(
                        name: "fk_study_resource_entity_subject_entity_study_resources_literature_id",
                        column: x => x.literature_id,
                        principalTable: "study_resources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_study_resource_entity_subject_entity_subjects_subjects_id",
                        column: x => x.subjects_id,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_course_works_mentor_id",
                table: "course_works",
                column: "mentor_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_works_student_id",
                table: "course_works",
                column: "student_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_mentor_entity_study_resource_entity_tagged_mentors_id",
                table: "mentor_entity_study_resource_entity",
                column: "tagged_mentors_id");

            migrationBuilder.CreateIndex(
                name: "ix_mentor_entity_subject_entity_subjects_id",
                table: "mentor_entity_subject_entity",
                column: "subjects_id");

            migrationBuilder.CreateIndex(
                name: "ix_students_course_id",
                table: "students",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "ix_study_resource_entity_subject_entity_subjects_id",
                table: "study_resource_entity_subject_entity",
                column: "subjects_id");

            migrationBuilder.CreateIndex(
                name: "ix_subjects_student_entity_id",
                table: "subjects",
                column: "student_entity_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blog_articles");

            migrationBuilder.DropTable(
                name: "course_works");

            migrationBuilder.DropTable(
                name: "mentor_entity_study_resource_entity");

            migrationBuilder.DropTable(
                name: "mentor_entity_subject_entity");

            migrationBuilder.DropTable(
                name: "study_resource_entity_subject_entity");

            migrationBuilder.DropTable(
                name: "mentors");

            migrationBuilder.DropTable(
                name: "study_resources");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
