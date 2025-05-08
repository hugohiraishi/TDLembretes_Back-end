using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDLembretes.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullComprovacaoUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ComprovacaoUrl",
                table: "TarefasOficial",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TarefasOficial",
                keyColumn: "ComprovacaoUrl",
                keyValue: null,
                column: "ComprovacaoUrl",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ComprovacaoUrl",
                table: "TarefasOficial",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");
        }
    }
}
