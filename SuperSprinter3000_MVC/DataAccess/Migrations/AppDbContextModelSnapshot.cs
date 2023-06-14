﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperSprinter3000_MVC.DataAccess;

#nullable disable

namespace SuperSprinter3000.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("SuperSprinter3000.DataAccess.Entities.UserStory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AcceptanceCriteria")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("BusinessValue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Estimation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserStories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AcceptanceCriteria = "Acceptance Criteria 1",
                            BusinessValue = 100,
                            Description = "Description 1",
                            Estimation = 0.5m,
                            Title = "User Story 1"
                        },
                        new
                        {
                            Id = 2,
                            AcceptanceCriteria = "Acceptance Criteria 2",
                            BusinessValue = 200,
                            Description = "Description 2",
                            Estimation = 1m,
                            Title = "User Story 2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
