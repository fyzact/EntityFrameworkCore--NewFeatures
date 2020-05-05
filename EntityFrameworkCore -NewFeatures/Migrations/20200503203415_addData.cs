using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore__NewFeatures.Migrations
{
    public partial class addData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blog",
                columns: new[] { "BlogId", "Name" },
                values: new object[] { 1, "First Blog" });

            migrationBuilder.InsertData(
                table: "Blog",
                columns: new[] { "BlogId", "Name" },
                values: new object[] { 2, "Second Blog" });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "PostId", "BlogId", "Content", "Title" },
                values: new object[,]
                {
                    { 1, 1, "First Post Content", "First Post Title" },
                    { 2, 1, "Second Post Content", "Second Post Title" },
                    { 3, 2, "Third Post Content", "Third Post Title" },
                    { 4, 2, "Fourth Post Content", "Fourth Post Title" },
                    { 5, 2, "Fiveth Post Content", "Fiveth Post Title" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 2);
        }
    }
}
