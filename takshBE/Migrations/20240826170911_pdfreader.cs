using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace takshBE.Migrations
{
    /// <inheritdoc />
    public partial class pdfreader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    pdfid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pdfname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subjectname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    standard = table.Column<int>(type: "int", nullable: false),
                    pdfcontent = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.pdfid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
