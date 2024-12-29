using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SZ.GerenciadorEstoque.Infra.Dados.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarDataVendaEmProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataVenda",
                table: "Produtos",
                type: "datetime2",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 8);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataVenda",
                table: "Produtos");
        }
    }
}
