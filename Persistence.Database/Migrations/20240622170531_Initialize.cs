using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    AddAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AddAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AddAt", "Document", "Email", "Lastname", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("13bf8a64-7eba-438d-8924-4d104cdbc2ed"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1682), "873481077", "email16@gmail.com", "Lastname 16", "Name 16", true },
                    { new Guid("18e205b8-302a-40ef-8775-0b3f72cfae64"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1618), "480182669", "email9@gmail.com", "Lastname 9", "Name 9", true },
                    { new Guid("21514763-cb2f-4d13-8c1d-8ce1703c4f09"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1661), "1417215968", "email11@gmail.com", "Lastname 11", "Name 11", true },
                    { new Guid("30659873-92f1-47f0-9c78-5d960aa1effa"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1611), "1858710846", "email7@gmail.com", "Lastname 7", "Name 7", true },
                    { new Guid("38468ce6-7e5e-4a91-9919-5471b2c447b5"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1671), "167807099", "email13@gmail.com", "Lastname 13", "Name 13", true },
                    { new Guid("453b7def-dd87-4871-8598-763d8ec7e4a7"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1667), "343695474", "email12@gmail.com", "Lastname 12", "Name 12", true },
                    { new Guid("4d5a810f-4d8f-4059-a482-6bbd9c1dcd02"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1685), "1575684674", "email17@gmail.com", "Lastname 17", "Name 17", true },
                    { new Guid("51427e38-3ad5-451a-8f90-d938b81c7d24"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1585), "1067725021", "email3@gmail.com", "Lastname 3", "Name 3", true },
                    { new Guid("6c298413-e54d-4122-a62c-ebe3e670684f"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1690), "188784348", "email18@gmail.com", "Lastname 18", "Name 18", true },
                    { new Guid("82d42bed-c61c-4a38-adab-16d2d6709aba"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1675), "1065682375", "email14@gmail.com", "Lastname 14", "Name 14", true },
                    { new Guid("894795e6-0d80-47b9-a9af-98f7ddd1dd34"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1699), "482206984", "email20@gmail.com", "Lastname 20", "Name 20", true },
                    { new Guid("93a0f331-1fe3-48e1-9e75-718c9e8f98fa"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1693), "1034557510", "email19@gmail.com", "Lastname 19", "Name 19", true },
                    { new Guid("96f138f3-346f-4855-bb8a-41dd682ef28d"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1608), "1845822705", "email6@gmail.com", "Lastname 6", "Name 6", true },
                    { new Guid("9f85a74e-3d80-4559-907f-4c1ae5b483c2"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1678), "1972469546", "email15@gmail.com", "Lastname 15", "Name 15", true },
                    { new Guid("b5b79001-6f3b-4a5b-8b87-f48585640eca"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1581), "683996117", "email2@gmail.com", "Lastname 2", "Name 2", true },
                    { new Guid("d186577a-5d59-4a89-88e3-21d6fd895dc6"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1562), "779092588", "email1@gmail.com", "Lastname 1", "Name 1", true },
                    { new Guid("dc971cf8-ba96-49a4-8a01-78047c3fb9b5"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1602), "1499654877", "email5@gmail.com", "Lastname 5", "Name 5", true },
                    { new Guid("ed39ed7f-a0f5-4757-b61f-e671502ec7ed"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1599), "1348145554", "email4@gmail.com", "Lastname 4", "Name 4", true },
                    { new Guid("f2593362-22ed-4152-a8bb-b2dc4eb45764"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1615), "2014887881", "email8@gmail.com", "Lastname 8", "Name 8", true },
                    { new Guid("ffad45e5-d6a5-4319-bc5e-9016c591faa9"), new DateTime(2024, 6, 22, 12, 5, 30, 740, DateTimeKind.Local).AddTicks(1624), "1917086477", "email10@gmail.com", "Lastname 10", "Name 10", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserID",
                table: "Tickets",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
