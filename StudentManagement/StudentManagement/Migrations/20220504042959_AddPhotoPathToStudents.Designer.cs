﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagement.Models;

namespace StudentManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220504042959_AddPhotoPathToStudents")]
    partial class AddPhotoPathToStudents
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentManagement.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassName");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PhotoPath");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new { Id = 1, ClassName = 4, Email = "shinevvip@gmail.com", Name = "李晓光" },
                        new { Id = 2, ClassName = 4, Email = "oliviachen797@gmail.com", Name = "陈婧瑶" },
                        new { Id = 3, ClassName = 4, Email = "haha@ffsd.com", Name = "张大拿" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
