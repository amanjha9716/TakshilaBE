using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace takshBE.Migrations
{
    /// <inheritdoc />
    public partial class sfsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    quesid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    standard = table.Column<int>(type: "int", nullable: false),
                    statement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    options = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.quesid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
