using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdatafordifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2ad7ea2d-88b2-4edb-9bf1-9d25e09e2bd8"), "Hard" },
                    { new Guid("bd5d44d6-a676-4d3d-8a85-6e2a2e4fd3ac"), "Medium" },
                    { new Guid("ed7bbcd4-ca54-4749-8b3e-3c8b79c09a4f"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("278f3905-dfe6-4504-854f-60aeaf7c9d41"), "WGN", "Wellington", "https://image.pexels.com/photos/wellington" },
                    { new Guid("66909005-8015-406b-8018-bf84cae00995"), "NSN", "Nelson", "https://image.pexels.com/photos/nelson" },
                    { new Guid("cb4edee6-7438-451b-8aaa-b2346645a39c"), "AKL", "Auckland", "https://image.pexels.com/photos/auckland" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2ad7ea2d-88b2-4edb-9bf1-9d25e09e2bd8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("bd5d44d6-a676-4d3d-8a85-6e2a2e4fd3ac"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ed7bbcd4-ca54-4749-8b3e-3c8b79c09a4f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("278f3905-dfe6-4504-854f-60aeaf7c9d41"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("66909005-8015-406b-8018-bf84cae00995"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cb4edee6-7438-451b-8aaa-b2346645a39c"));
        }
    }
}
