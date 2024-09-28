﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymTracker2.Migrations
{
    [DbContext(typeof(GymContext))]
    [Migration("20240928112246_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GymTracker2.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bench Press"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Barbell Squat"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Barbell Deadlift"
                        });
                });

            modelBuilder.Entity("GymTracker2.Models.TrackingEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("LoadInKg")
                        .HasColumnType("int");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("TrackingEntries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2024, 9, 28, 21, 22, 46, 433, DateTimeKind.Local).AddTicks(1081),
                            ExerciseId = 1,
                            LoadInKg = 80,
                            Reps = 10,
                            Sets = 3
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2024, 9, 28, 21, 22, 46, 433, DateTimeKind.Local).AddTicks(1123),
                            ExerciseId = 2,
                            LoadInKg = 100,
                            Reps = 8,
                            Sets = 3
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2024, 9, 28, 21, 22, 46, 433, DateTimeKind.Local).AddTicks(1125),
                            ExerciseId = 3,
                            LoadInKg = 120,
                            Reps = 5,
                            Sets = 3
                        });
                });

            modelBuilder.Entity("GymTracker2.Models.TrackingEntry", b =>
                {
                    b.HasOne("GymTracker2.Models.Exercise", "Exercise")
                        .WithMany("TrackingEntries")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("GymTracker2.Models.Exercise", b =>
                {
                    b.Navigation("TrackingEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
