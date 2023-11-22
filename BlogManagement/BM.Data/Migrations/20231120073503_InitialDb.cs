using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BM.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });
            //insert data into categories table
            migrationBuilder.InsertData(
            table: "Categories",
            columns: new[] { "Name", "UrlSlug", "Description" },
            values: new object[,]
            {
                { "Technology", "technology", "All about the latest in technology" },
                { "Science", "science", "Explore the wonders of science" },
                { "Art", "art", "Dive into the world of art" },
                { "Literature", "literature", "Discover the beauty of literature" },
                { "Travel", "travel", "Join us on a journey around the world" }
            });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            //insert data into Tags table
            migrationBuilder.InsertData(
            table: "Tags",
            columns: new[] { "Name", "UrlSlug", "Description", "Count" },
            values: new object[,]
            {
                { "Science", "science", "Posts related to scientific discoveries and advancements", 20 },
                { "Technology", "technology", "Posts about the latest technology trends and gadgets", 15 },
                { "Travel", "travel", "Posts about travel experiences and guides", 10 },
                { "Art", "art", "Posts exploring various art forms and artists", 12 },
                { "Literature", "literature", "Posts discussing literature and book reviews", 8 }
            });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostContent = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //insert data into Posts table
            migrationBuilder.InsertData(
            table: "Posts",
            columns: new[] { "Title", "ShortDescription", "PostContent", "UrlSlug", "Published", "PostedOn", "Modified", "CategoryId" },
            values: new object[,]
            {
                { "Exploring the Cosmos", "A short introduction to space exploration", "Content of the post goes here...", "exploring-the-cosmos", DateTime.UtcNow, DateTime.UtcNow, DateTime.UtcNow, 1 },
                { "The Art of Painting", "A look into the world of painting", "Content of the post goes here...", "the-art-of-painting", DateTime.UtcNow, DateTime.UtcNow, DateTime.UtcNow, 2 },
                { "Understanding Quantum Physics", "A beginner's guide to quantum physics", "Content of the post goes here...", "understanding-quantum-physics", DateTime.UtcNow, DateTime.UtcNow, DateTime.UtcNow, 3 },
                { "The Future of Tech", "Predicting the next big thing in technology", "Content of the post goes here...", "the-future-of-tech", DateTime.UtcNow, DateTime.UtcNow, DateTime.UtcNow, 4 },
                { "Traveling Through Europe", "A travel guide for Europe", "Content of the post goes here...", "traveling-through-europe", DateTime.UtcNow, DateTime.UtcNow, DateTime.UtcNow, 5 }
            });


            migrationBuilder.CreateTable(
                name: "PostTagMaps",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMaps", x => new { x.TagId, x.PostId });
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMaps_PostId",
                table: "PostTagMaps",
                column: "PostId");

            //insert data into PostTagMaps table
            migrationBuilder.InsertData(
            table: "PostTagMaps",
            columns: new[] { "TagId", "PostId" },
            values: new object[,]
            {
                { 1, 1 },
                { 2, 2 },
                { 3, 3 },
                { 4, 4 },
                { 5, 5 }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTagMaps");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
