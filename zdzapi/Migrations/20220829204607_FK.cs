using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zdzapi.Migrations
{
    public partial class FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProduto",
                table: "Fornecedor",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "Fornecedor");
        }
    }
}
