using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyLastApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operacoes",
                columns: table => new
                {
                    IdOperacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoOperacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataOperacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Versao = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacoes", x => x.IdOperacao);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    DataNasc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    IdConta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    Bloqueada = table.Column<bool>(type: "bit", nullable: false),
                    LimiteDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.IdConta);
                    table.ForeignKey(
                        name: "FK_Contas_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cpf", "DataNasc", "Nome" },
                values: new object[,]
                {
                    { 1, "08995228407", new DateTime(1992, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" },
                    { 2, "60671150006", new DateTime(1963, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fatima" },
                    { 3, "47633984074", new DateTime(1980, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orlando" }
                });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "IdConta", "Ativa", "Bloqueada", "ClienteId", "LimiteDiario", "Saldo" },
                values: new object[,]
                {
                    { 1, true, false, 1, 0m, 0m },
                    { 2, true, false, 2, 0m, 0m },
                    { 3, true, false, 3, 0m, 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contas_ClienteId",
                table: "Contas",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Operacoes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
