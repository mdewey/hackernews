using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace hackernews.Migrations
{
    public partial class AddNewStory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsStory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Body = table.Column<string>(type: "text", nullable: true),
                    Points = table.Column<int>(type: "int4", nullable: false),
                    Submitter = table.Column<string>(type: "text", nullable: true),
                    TimePosted = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsStory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsStory");
        }
    }
}
