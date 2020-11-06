﻿// <auto-generated />
using System;
using IvySchool.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IvySchool.Data.Migrations
{
    [DbContext(typeof(IvySchoolContext))]
    partial class IvySchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("IvySchool.Data.Entities.RoleDb", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Role");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("IvySchool.Data.Entities.RoleUserDb", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUsers");
                });

            modelBuilder.Entity("IvySchool.Data.Entities.SigninHistoryDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SigninIp");

                    b.Property<DateTime>("SigninTime");

                    b.Property<int>("userId");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("signIns");
                });

            modelBuilder.Entity("IvySchool.Data.Entities.StudentDb", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Avatar");

                    b.Property<string>("City");

                    b.Property<string>("Mobile");

                    b.Property<string>("Notes");

                    b.Property<int>("NumberOfLogins");

                    b.Property<string>("School");

                    b.Property<string>("SignUpSource");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("StudentId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Student");
                });

            modelBuilder.Entity("IvySchool.Data.Entities.UserDb", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("IvySchool.Data.Entities.RoleUserDb", b =>
                {
                    b.HasOne("IvySchool.Data.Entities.RoleDb", "Role")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IvySchool.Data.Entities.UserDb", "User")
                        .WithMany("RoleUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IvySchool.Data.Entities.SigninHistoryDb", b =>
                {
                    b.HasOne("IvySchool.Data.Entities.UserDb", "user")
                        .WithMany("SignIns")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IvySchool.Data.Entities.StudentDb", b =>
                {
                    b.HasOne("IvySchool.Data.Entities.UserDb", "User")
                        .WithOne("Student")
                        .HasForeignKey("IvySchool.Data.Entities.StudentDb", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
