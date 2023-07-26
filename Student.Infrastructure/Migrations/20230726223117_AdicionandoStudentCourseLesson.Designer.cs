﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Student.Infrastructure.Context;

#nullable disable

namespace Student.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230726223117_AdicionandoStudentCourseLesson")]
    partial class AdicionandoStudentCourseLesson
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Student.Domain.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CourseId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Duration")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int?>("Enrollmentstatusid")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<double?>("Price")
                        .IsRequired()
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("RegisterDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CourseId");

                    b.HasIndex("Enrollmentstatusid");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Student.Domain.Entities.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LessonId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<string>("DescriptionLesson")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("DurationLesson")
                        .HasColumnType("integer");

                    b.Property<string>("TitleLesson")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("VideoLesson")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("LessonId");

                    b.HasIndex("CourseId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Student.Domain.Entities.StudentCourse", b =>
                {
                    b.Property<int>("StudentCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentCourseId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<int?>("CourseId1")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Grade")
                        .HasColumnType("double precision");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("StudentenId")
                        .HasColumnType("integer");

                    b.Property<int?>("StudentenId1")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UrlRepository")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("StudentCourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("CourseId1");

                    b.HasIndex("StudentenId");

                    b.HasIndex("StudentenId1");

                    b.ToTable("StudentsCourses");
                });

            modelBuilder.Entity("Student.Domain.Entities.StudentCourseLesson", b =>
                {
                    b.Property<int>("StudentCourseLessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentCourseLessonId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<int>("LessonId")
                        .HasColumnType("integer");

                    b.Property<int>("StudentenId")
                        .HasColumnType("integer");

                    b.HasKey("StudentCourseLessonId");

                    b.HasIndex("CourseId");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentenId");

                    b.ToTable("StudentCourseLessons");
                });

            modelBuilder.Entity("Student.Domain.Entities.Studenten", b =>
                {
                    b.Property<int>("StudentenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentenId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("StudentenId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Student.Domain.Enum.Enrollmentstatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Enrollmentstatus");
                });

            modelBuilder.Entity("Student.Domain.Entities.Course", b =>
                {
                    b.HasOne("Student.Domain.Enum.Enrollmentstatus", "Enrollmentstatus")
                        .WithMany("Courses")
                        .HasForeignKey("Enrollmentstatusid");

                    b.Navigation("Enrollmentstatus");
                });

            modelBuilder.Entity("Student.Domain.Entities.Lesson", b =>
                {
                    b.HasOne("Student.Domain.Entities.Course", "Courses")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Student.Domain.Entities.StudentCourse", b =>
                {
                    b.HasOne("Student.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student.Domain.Entities.Course", null)
                        .WithMany("StudentCourse")
                        .HasForeignKey("CourseId1");

                    b.HasOne("Student.Domain.Entities.Studenten", "Studenten")
                        .WithMany()
                        .HasForeignKey("StudentenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student.Domain.Entities.Studenten", null)
                        .WithMany("StudentCourse")
                        .HasForeignKey("StudentenId1");

                    b.Navigation("Course");

                    b.Navigation("Studenten");
                });

            modelBuilder.Entity("Student.Domain.Entities.StudentCourseLesson", b =>
                {
                    b.HasOne("Student.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student.Domain.Entities.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student.Domain.Entities.Studenten", "Studenten")
                        .WithMany()
                        .HasForeignKey("StudentenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Lesson");

                    b.Navigation("Studenten");
                });

            modelBuilder.Entity("Student.Domain.Entities.Course", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("StudentCourse");
                });

            modelBuilder.Entity("Student.Domain.Entities.Studenten", b =>
                {
                    b.Navigation("StudentCourse");
                });

            modelBuilder.Entity("Student.Domain.Enum.Enrollmentstatus", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}