using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace takshBE.Migrations
{
    /// <inheritdoc />
    public partial class nexttopics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "stand",
                table: "NextTopics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stand",
                table: "NextTopics");
        }
    }
}
