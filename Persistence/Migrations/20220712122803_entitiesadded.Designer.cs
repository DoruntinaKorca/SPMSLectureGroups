﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(LectureGroupContext))]
    [Migration("20220712122803_entitiesadded")]
    partial class entitiesadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.AcademicStaff", b =>
                {
                    b.Property<Guid>("AcademicStaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AcademicStaffId");

                    b.ToTable("AcademicStaff");
                });

            modelBuilder.Entity("Domain.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Domain.Course_AcademicStaff", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<Guid>("AcademicStaffId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CourseId", "AcademicStaffId");

                    b.HasIndex("AcademicStaffId");

                    b.ToTable("Course_AcademicStaff");
                });

            modelBuilder.Entity("Domain.Day", b =>
                {
                    b.Property<int>("DayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DayName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DayId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("Domain.Lecture", b =>
                {
                    b.Property<int>("LectureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("AcademicStaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("DayId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LectureGroupId")
                        .HasColumnType("int");

                    b.Property<int>("LectureHallId")
                        .HasColumnType("int");

                    b.Property<string>("LectureType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("LectureId");

                    b.HasIndex("DayId");

                    b.HasIndex("LectureGroupId");

                    b.HasIndex("LectureHallId");

                    b.HasIndex("CourseId", "AcademicStaffId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("Domain.LectureGroup", b =>
                {
                    b.Property<int>("LectureGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LGRSId")
                        .HasColumnType("int");

                    b.Property<int?>("TimeSlotId")
                        .HasColumnType("int");

                    b.HasKey("LectureGroupId");

                    b.HasIndex("LGRSId");

                    b.HasIndex("TimeSlotId");

                    b.ToTable("LectureGroups");
                });

            modelBuilder.Entity("Domain.LectureGroupRegisteringSeason", b =>
                {
                    b.Property<int>("LGRSId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Faculty")
                        .HasColumnType("int");

                    b.Property<string>("LectureGroupSeasonStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LGRSId");

                    b.ToTable("LGRS");
                });

            modelBuilder.Entity("Domain.LectureHall", b =>
                {
                    b.Property<int>("LectureHallId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("HallName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("LectureHallId");

                    b.HasIndex("LocationId");

                    b.ToTable("LectureHalls");
                });

            modelBuilder.Entity("Domain.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Domain.TimeSlot", b =>
                {
                    b.Property<int>("TimeSlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SlotName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TimeSlotId");

                    b.ToTable("TimeSlots");
                });

            modelBuilder.Entity("Domain.Course_AcademicStaff", b =>
                {
                    b.HasOne("Domain.AcademicStaff", "AcademicStaff")
                        .WithMany("CourseAcademicStaff")
                        .HasForeignKey("AcademicStaffId")
                        .HasConstraintName("academicStaffCourse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Course", "Course")
                        .WithMany("CourseAcademicStaff")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("courseAcademicStaff")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicStaff");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Domain.Lecture", b =>
                {
                    b.HasOne("Domain.Day", "Day")
                        .WithMany("Lectures")
                        .HasForeignKey("DayId")
                        .HasConstraintName("Lectures_Days")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.LectureGroup", "LectureGroup")
                        .WithMany("Lectures")
                        .HasForeignKey("LectureGroupId")
                        .HasConstraintName("Lectures_Groups")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.LectureHall", "LectureHall")
                        .WithMany("Lectures")
                        .HasForeignKey("LectureHallId")
                        .HasConstraintName("Lectures_Halls")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Course_AcademicStaff", "Course_AcademicStaff")
                        .WithMany("Lectures")
                        .HasForeignKey("CourseId", "AcademicStaffId")
                        .HasConstraintName("courseAcademicSTAFF_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course_AcademicStaff");

                    b.Navigation("Day");

                    b.Navigation("LectureGroup");

                    b.Navigation("LectureHall");
                });

            modelBuilder.Entity("Domain.LectureGroup", b =>
                {
                    b.HasOne("Domain.LectureGroupRegisteringSeason", "LGRS")
                        .WithMany("LectureGroups")
                        .HasForeignKey("LGRSId")
                        .HasConstraintName("LG_LGRS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.TimeSlot", "TimeSlot")
                        .WithMany("LectureGroups")
                        .HasForeignKey("TimeSlotId")
                        .HasConstraintName("Lecturegroupss_timest");

                    b.Navigation("LGRS");

                    b.Navigation("TimeSlot");
                });

            modelBuilder.Entity("Domain.LectureHall", b =>
                {
                    b.HasOne("Domain.Location", "Location")
                        .WithMany("LectureHalls")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("locationhall")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.AcademicStaff", b =>
                {
                    b.Navigation("CourseAcademicStaff");
                });

            modelBuilder.Entity("Domain.Course", b =>
                {
                    b.Navigation("CourseAcademicStaff");
                });

            modelBuilder.Entity("Domain.Course_AcademicStaff", b =>
                {
                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("Domain.Day", b =>
                {
                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("Domain.LectureGroup", b =>
                {
                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("Domain.LectureGroupRegisteringSeason", b =>
                {
                    b.Navigation("LectureGroups");
                });

            modelBuilder.Entity("Domain.LectureHall", b =>
                {
                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("Domain.Location", b =>
                {
                    b.Navigation("LectureHalls");
                });

            modelBuilder.Entity("Domain.TimeSlot", b =>
                {
                    b.Navigation("LectureGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
