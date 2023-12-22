﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SportMan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportMan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoreWeigth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Snatch = table.Column<int>(type: "int", nullable: false),
                    Jerk = table.Column<int>(type: "int", nullable: false),
                    TotalWeigth = table.Column<int>(type: "int", nullable: false),
                    SportManId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreWeigth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoreWeigth_SportMan_SportManId",
                        column: x => x.SportManId,
                        principalTable: "SportMan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScoreWeigth_SportManId",
                table: "ScoreWeigth",
                column: "SportManId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScoreWeigth");

            migrationBuilder.DropTable(
                name: "SportMan");
        }
    }
}
