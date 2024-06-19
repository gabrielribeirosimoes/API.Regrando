using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace regrando.API.Migrations
{
    /// <inheritdoc />
    public partial class AnotherCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CADASTRO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Login = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Senha = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    AceitouTermos = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CADASTRO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_CADASTRO_TB_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_USUARIO",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_RECEITA",
                columns: table => new
                {
                    IdReceita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeReceita = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Ingredientes = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ModoPreparo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Calorias = table.Column<int>(type: "int", nullable: false),
                    TempoPreparoMinutos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RECEITA", x => x.IdReceita);
                });

            migrationBuilder.UpdateData(
                table: "TB_OBJETIVO",
                keyColumn: "IdObjetivo",
                keyValue: 2,
                column: "IdUsuario",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_OBJETIVO",
                keyColumn: "IdObjetivo",
                keyValue: 3,
                column: "IdUsuario",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_OBJETIVO",
                keyColumn: "IdObjetivo",
                keyValue: 4,
                column: "IdUsuario",
                value: 4);

            migrationBuilder.InsertData(
                table: "TB_RECEITA",
                columns: new[] { "IdReceita", "Calorias", "Descricao", "Ingredientes", "ModoPreparo", "NomeReceita", "TempoPreparoMinutos" },
                values: new object[,]
                {
                    { 1, 200, "Delicioso bolo de cenoura com cobertura de chocolate", "Cenoura, óleo, ovos, açúcar, farinha de trigo, fermento em pó, chocolate", "1. Bata no liquidificador as cenouras, óleo e ovos. 2. Adicione o açúcar e a farinha de trigo. 3. Por último, coloque o fermento e misture delicadamente. 4. Asse em forno médio por aproximadamente 40 minutos.", "Bolo de cenoura", 40 },
                    { 2, 150, "Salada refrescante com quinoa, tomate, pepino e temperos", "Quinoa, tomate, pepino, azeite, limão, sal", "1. Cozinhe a quinoa conforme as instruções da embalagem. 2. Corte os tomates e pepinos em cubos. 3. Misture tudo e tempere a gosto. 4. Sirva frio.", "Salada de quinoa", 30 }
                });

            migrationBuilder.UpdateData(
                table: "TB_REFEICOES",
                keyColumn: "IdRefeicao",
                keyValue: 2,
                column: "IdUsuario",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_TB_OBJETIVO_IdUsuario",
                table: "TB_OBJETIVO",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_CADASTRO_UsuarioId",
                table: "TB_CADASTRO",
                column: "UsuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CADASTRO");

            migrationBuilder.DropTable(
                name: "TB_RECEITA");

            migrationBuilder.DropIndex(
                name: "IX_TB_OBJETIVO_IdUsuario",
                table: "TB_OBJETIVO");

            migrationBuilder.UpdateData(
                table: "TB_OBJETIVO",
                keyColumn: "IdObjetivo",
                keyValue: 2,
                column: "IdUsuario",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_OBJETIVO",
                keyColumn: "IdObjetivo",
                keyValue: 3,
                column: "IdUsuario",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_OBJETIVO",
                keyColumn: "IdObjetivo",
                keyValue: 4,
                column: "IdUsuario",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_REFEICOES",
                keyColumn: "IdRefeicao",
                keyValue: 2,
                column: "IdUsuario",
                value: 1);
        }
    }
}
