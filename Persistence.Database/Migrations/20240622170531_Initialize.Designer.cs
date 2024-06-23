﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Database;

#nullable disable

namespace Persistence.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240622170531_Initialize")]
    partial class Initialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Tickets", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Domain.Users", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Document")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = new Guid("d186577a-5d59-4a89-88e3-21d6fd895dc6"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1562),
                            Document = "779092588",
                            Email = "email1@gmail.com",
                            Lastname = "Lastname 1",
                            Name = "Name 1",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("b5b79001-6f3b-4a5b-8b87-f48585640eca"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1581),
                            Document = "683996117",
                            Email = "email2@gmail.com",
                            Lastname = "Lastname 2",
                            Name = "Name 2",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("51427e38-3ad5-451a-8f90-d938b81c7d24"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1585),
                            Document = "1067725021",
                            Email = "email3@gmail.com",
                            Lastname = "Lastname 3",
                            Name = "Name 3",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("ed39ed7f-a0f5-4757-b61f-e671502ec7ed"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1599),
                            Document = "1348145554",
                            Email = "email4@gmail.com",
                            Lastname = "Lastname 4",
                            Name = "Name 4",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("dc971cf8-ba96-49a4-8a01-78047c3fb9b5"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1602),
                            Document = "1499654877",
                            Email = "email5@gmail.com",
                            Lastname = "Lastname 5",
                            Name = "Name 5",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("96f138f3-346f-4855-bb8a-41dd682ef28d"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1608),
                            Document = "1845822705",
                            Email = "email6@gmail.com",
                            Lastname = "Lastname 6",
                            Name = "Name 6",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("30659873-92f1-47f0-9c78-5d960aa1effa"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1611),
                            Document = "1858710846",
                            Email = "email7@gmail.com",
                            Lastname = "Lastname 7",
                            Name = "Name 7",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("f2593362-22ed-4152-a8bb-b2dc4eb45764"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1615),
                            Document = "2014887881",
                            Email = "email8@gmail.com",
                            Lastname = "Lastname 8",
                            Name = "Name 8",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("18e205b8-302a-40ef-8775-0b3f72cfae64"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1618),
                            Document = "480182669",
                            Email = "email9@gmail.com",
                            Lastname = "Lastname 9",
                            Name = "Name 9",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("ffad45e5-d6a5-4319-bc5e-9016c591faa9"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1624),
                            Document = "1917086477",
                            Email = "email10@gmail.com",
                            Lastname = "Lastname 10",
                            Name = "Name 10",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("21514763-cb2f-4d13-8c1d-8ce1703c4f09"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1661),
                            Document = "1417215968",
                            Email = "email11@gmail.com",
                            Lastname = "Lastname 11",
                            Name = "Name 11",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("453b7def-dd87-4871-8598-763d8ec7e4a7"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1667),
                            Document = "343695474",
                            Email = "email12@gmail.com",
                            Lastname = "Lastname 12",
                            Name = "Name 12",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("38468ce6-7e5e-4a91-9919-5471b2c447b5"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1671),
                            Document = "167807099",
                            Email = "email13@gmail.com",
                            Lastname = "Lastname 13",
                            Name = "Name 13",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("82d42bed-c61c-4a38-adab-16d2d6709aba"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1675),
                            Document = "1065682375",
                            Email = "email14@gmail.com",
                            Lastname = "Lastname 14",
                            Name = "Name 14",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("9f85a74e-3d80-4559-907f-4c1ae5b483c2"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1678),
                            Document = "1972469546",
                            Email = "email15@gmail.com",
                            Lastname = "Lastname 15",
                            Name = "Name 15",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("13bf8a64-7eba-438d-8924-4d104cdbc2ed"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1682),
                            Document = "873481077",
                            Email = "email16@gmail.com",
                            Lastname = "Lastname 16",
                            Name = "Name 16",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("4d5a810f-4d8f-4059-a482-6bbd9c1dcd02"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1685),
                            Document = "1575684674",
                            Email = "email17@gmail.com",
                            Lastname = "Lastname 17",
                            Name = "Name 17",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("6c298413-e54d-4122-a62c-ebe3e670684f"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1690),
                            Document = "188784348",
                            Email = "email18@gmail.com",
                            Lastname = "Lastname 18",
                            Name = "Name 18",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("93a0f331-1fe3-48e1-9e75-718c9e8f98fa"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1693),
                            Document = "1034557510",
                            Email = "email19@gmail.com",
                            Lastname = "Lastname 19",
                            Name = "Name 19",
                            Status = true
                        },
                        new
                        {
                            UserID = new Guid("894795e6-0d80-47b9-a9af-98f7ddd1dd34"),
                            AddAt = new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1699),
                            Document = "482206984",
                            Email = "email20@gmail.com",
                            Lastname = "Lastname 20",
                            Name = "Name 20",
                            Status = true
                        });
                });

            modelBuilder.Entity("Domain.Tickets", b =>
                {
                    b.HasOne("Domain.Users", "UsersNavigation")
                        .WithMany("Tickets")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsersNavigation");
                });

            modelBuilder.Entity("Domain.Users", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}