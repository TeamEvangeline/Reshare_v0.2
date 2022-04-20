﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reshare_proto_0._2.Repository;

namespace Reshare_proto_0._2.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20220417164819_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reshare_proto_0._2.Models.CityModel", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CityId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CityName");

                    b.Property<int>("StateId")
                        .HasColumnType("int")
                        .HasColumnName("StateId");

                    b.HasKey("CityId");

                    b.ToTable("tblCity", "dim");
                });

            modelBuilder.Entity("Reshare_proto_0._2.Models.CountryModel", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("CountryId");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CountryName");

                    b.Property<string>("PhoneCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhoneCode");

                    b.HasKey("CountryId");

                    b.ToTable("tblCountry", "dim");
                });

            modelBuilder.Entity("Reshare_proto_0._2.Models.ImageModel", b =>
                {
                    b.Property<int>("ImgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ImgId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Url");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ImgId");

                    b.HasIndex("UserId");

                    b.ToTable("tblImages");
                });

            modelBuilder.Entity("Reshare_proto_0._2.Models.LocationModel", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("LocationId");

                    b.ToTable("tblLocation", "dim");
                });

            modelBuilder.Entity("Reshare_proto_0._2.Models.StateModel", b =>
                {
                    b.Property<int>("StateId")
                        .HasColumnType("int")
                        .HasColumnName("StateId");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CountryId");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("StateName");

                    b.HasKey("StateId");

                    b.ToTable("tblState", "dim");
                });

            modelBuilder.Entity("Reshare_proto_0._2.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhoneNbr");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("LocationId")
                        .IsUnique()
                        .HasFilter("[LocationId] IS NOT NULL");

                    b.ToTable("tblUser");
                });

            modelBuilder.Entity("Reshare_proto_0._2.Models.CountryModel", b =>
                {
                    b.HasOne("Reshare_proto_0._2.Models.LocationModel", "Location")
                        .WithOne("Country")
                        .HasForeignKey("Reshare_proto_0._2.Models.CountryModel", "CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reshare_proto_0._2.Models.StateModel", "State")
                        .WithOne("Country")
                        .HasForeignKey("Reshare_proto_0._2.Models.CountryModel", "CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Reshare_proto_0._2.Models.ImageModel", b =>
                {
                    b.HasOne("Reshare_proto_0._2.Models.UserModel", "User")
                        .WithMany("Images")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Reshare_proto_0._2.Models.StateModel", b =>
                {
                    b.HasOne("Reshare_proto_0._2.Models.CityModel", "City")
                        .WithOne("State")
                        .HasForeignKey("Reshare_proto_0._2.Models.StateModel", "StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Reshare_proto_0._2.Models.UserModel", b =>
                {
                    b.HasOne("Reshare_proto_0._2.Models.LocationModel", "Location")
                        .WithOne("User")
                        .HasForeignKey("Reshare_proto_0._2.Models.UserModel", "LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Reshare_proto_0._2.Models.CityModel", b =>
                {
                    b.Navigation("State");
                });

            modelBuilder.Entity("Reshare_proto_0._2.Models.LocationModel", b =>
                {
                    b.Navigation("Country");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Reshare_proto_0._2.Models.StateModel", b =>
                {
                    b.Navigation("Country");
                });

            modelBuilder.Entity("Reshare_proto_0._2.Models.UserModel", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}