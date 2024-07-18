﻿// <auto-generated />
using Downloads.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Downloads.Migrations
{
    [DbContext(typeof(NotForzaContext))]
    [Migration("20240718094838_UserLoginCreds")]
    partial class UserLoginCreds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("Downloads.Data.Car", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarCost")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CarDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("CarGrade")
                        .HasColumnType("TEXT");

                    b.Property<string>("CarModel")
                        .HasColumnType("TEXT");

                    b.Property<string>("CarName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CarPicURL")
                        .HasColumnType("TEXT");

                    b.Property<int>("CarYear")
                        .HasColumnType("INTEGER");

                    b.HasKey("CarID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Downloads.Data.Credentials", b =>
                {
                    b.Property<int>("PasswordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PlayerID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Salty")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PasswordID");

                    b.HasIndex("PlayerID");

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("Downloads.Data.PlayerStats", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<int>("Currency")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HouseLocation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfilePic")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RankLevel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SocialLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("XP")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayerID");

                    b.ToTable("PlayerStats");
                });

            modelBuilder.Entity("Downloads.Data.Credentials", b =>
                {
                    b.HasOne("Downloads.Data.PlayerStats", "PlayerStats")
                        .WithMany()
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerStats");
                });
#pragma warning restore 612, 618
        }
    }
}