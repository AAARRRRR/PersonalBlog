using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBlog.Migrations
{
    /// <inheritdoc />
    public partial class AddArticleSummaryColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Articles");
        }
    }
}
