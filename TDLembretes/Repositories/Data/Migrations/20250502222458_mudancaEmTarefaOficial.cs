using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDLembretes.Migrations
{
    /// <inheritdoc />
    public partial class mudancaEmTarefaOficial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataConclusao",
                table: "TarefasOficial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataConclusao",
                table: "TarefasOficial",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
