using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "date", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.IdFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "Dependente",
                columns: table => new
                {
                    IdDependente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "Date", nullable: false),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependente", x => x.IdDependente);
                    table.ForeignKey(
                        name: "FK_Dependente_Funcionario_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependente_IdFuncionario",
                table: "Dependente",
                column: "IdFuncionario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependente");

            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
