using Microsoft.EntityFrameworkCore.Migrations;

namespace CVBuilder.Repository.Migrations
{
    public partial class TemplateContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "TemplateId", "Name", "Path" },
                values: new object[] { 1, "Classic", "/assets/img/templates/classic.png" });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "TemplateId", "Name", "Path" },
                values: new object[] { 2, "Elegant", "/assets/img/templates/elegant.png" });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "TemplateId", "Name", "Path" },
                values: new object[] { 3, "Modern", "/assets/img/templates/modern.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "TemplateId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "TemplateId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "TemplateId",
                keyValue: 3);
        }
    }
}
