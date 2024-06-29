using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infotrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateSearchEngineTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchEngines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegEx = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchEngines", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SearchEngines",
                columns: new[] { "Id", "BaseUrl", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name", "RegEx" },
                values: new object[] { new Guid("576248bd-8b8c-4ede-8a1e-8efd6c84110a"), "https://www.google.co.uk/search?num={0}&q={1}", null, null, null, null, "Google", "<div\\s+class=\"BNeawe\\s+UPmit\\s+AP7Wnd\\s+lRVwie\">([^<]*)<\\/div>" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchEngines");
        }
    }
}
