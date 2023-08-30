﻿// <auto-generated />
using System;
using GrivenceCellForCollage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrivenceCellForCollage.Migrations
{
    [DbContext(typeof(CollageDbContext))]
    partial class CollageDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GrivenceCellForCollage.Models.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BranchId"));

                    b.Property<string>("BranchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegisterId")
                        .HasColumnType("int");

                    b.HasKey("BranchId");

                    b.HasIndex("RegisterId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("GrivenceCellForCollage.Models.CompaintBox", b =>
                {
                    b.Property<int>("ComplaintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComplaintId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int?>("regiId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComplaintId");

                    b.HasIndex("regiId");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("GrivenceCellForCollage.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<int>("DepartmentName")
                        .HasColumnType("int");

                    b.Property<int?>("RegisterId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.HasIndex("RegisterId");

                    b.HasIndex("UsersId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("GrivenceCellForCollage.Models.Register", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<long>("MobileNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Password")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Registers");
                });

            modelBuilder.Entity("GrivenceCellForCollage.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GrivenceCellForCollage.Models.Branch", b =>
                {
                    b.HasOne("GrivenceCellForCollage.Models.Register", null)
                        .WithMany("Branchs")
                        .HasForeignKey("RegisterId");
                });

            modelBuilder.Entity("GrivenceCellForCollage.Models.CompaintBox", b =>
                {
                    b.HasOne("GrivenceCellForCollage.Models.Register", "regi")
                        .WithMany()
                        .HasForeignKey("regiId");

                    b.Navigation("regi");
                });

            modelBuilder.Entity("GrivenceCellForCollage.Models.Department", b =>
                {
                    b.HasOne("GrivenceCellForCollage.Models.Register", null)
                        .WithMany("Category")
                        .HasForeignKey("RegisterId");

                    b.HasOne("GrivenceCellForCollage.Models.Users", null)
                        .WithMany("Category")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("GrivenceCellForCollage.Models.Users", b =>
                {
                    b.HasOne("GrivenceCellForCollage.Models.Register", "register")
                        .WithOne("User")
                        .HasForeignKey("GrivenceCellForCollage.Models.Users", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("register");
                });

            modelBuilder.Entity("GrivenceCellForCollage.Models.Register", b =>
                {
                    b.Navigation("Branchs");

                    b.Navigation("Category");

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("GrivenceCellForCollage.Models.Users", b =>
                {
                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
