using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace regrando.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_AGUAS",
                columns: table => new
                {
                    IdAgua = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HrAgua = table.Column<TimeSpan>(type: "time", nullable: true),
                    QtdAgua = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_AGUAS", x => x.IdAgua);
                });

            migrationBuilder.CreateTable(
                name: "TB_REFEICOES",
                columns: table => new
                {
                    IdRefeicao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdAlimento = table.Column<int>(type: "int", nullable: false),
                    TpRefeicao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    HrRefeicao = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_REFEICOES", x => x.IdRefeicao);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<double>(type: "float", nullable: false),
                    Sexo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Objetivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.IdUsuario);
                });

            migrationBuilder.InsertData(
                table: "TB_AGUAS",
                columns: new[] { "IdAgua", "HrAgua", "QtdAgua" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 8, 0, 0, 0), 200 },
                    { 2, new TimeSpan(0, 12, 0, 0, 0), 300 }
                });

            migrationBuilder.InsertData(
                table: "TB_REFEICOES",
                columns: new[] { "IdRefeicao", "HrRefeicao", "IdAlimento", "IdUsuario", "TpRefeicao" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 12, 0, 0, 0), 1, 1, "Almoço" },
                    { 2, new TimeSpan(0, 19, 0, 0, 0), 2, 1, "Jantar" }
                });

            migrationBuilder.InsertData(
                table: "TB_USUARIO",
                columns: new[] { "IdUsuario", "Altura", "Cpf", "Nome", "Objetivo", "Peso", "Sexo" },
                values: new object[] { 1, 1.75, "123456789", "Exemplo", 1, 70, "Masculino" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_AGUAS");

            migrationBuilder.DropTable(
                name: "TB_REFEICOES");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
