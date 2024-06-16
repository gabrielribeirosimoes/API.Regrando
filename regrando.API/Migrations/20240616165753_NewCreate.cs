using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace regrando.API.Migrations
{
    /// <inheritdoc />
    public partial class NewCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ALIMENTO",
                columns: table => new
                {
                    IdAlimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAlimento = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Carboidratos = table.Column<double>(type: "float", nullable: false),
                    Gorduras = table.Column<double>(type: "float", nullable: false),
                    Proteinas = table.Column<double>(type: "float", nullable: false),
                    Calorias = table.Column<double>(type: "float", nullable: false),
                    Fibras = table.Column<double>(type: "float", nullable: false),
                    Sodio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALIMENTO", x => x.IdAlimento);
                });

            migrationBuilder.CreateTable(
                name: "TB_OBJETIVO",
                columns: table => new
                {
                    IdObjetivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    DsObjetivo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    TipoObjetivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_OBJETIVO", x => x.IdObjetivo);
                });

            migrationBuilder.InsertData(
                table: "TB_ALIMENTO",
                columns: new[] { "IdAlimento", "Calorias", "Carboidratos", "Fibras", "Gorduras", "NomeAlimento", "Proteinas", "Sodio" },
                values: new object[,]
                {
                    { 1, 124.0, 25.800000000000001, 0.40000000000000002, 0.29999999999999999, "Arroz branco cozido", 2.6000000000000001, 1.0 },
                    { 2, 77.0, 14.5, 6.4000000000000004, 0.5, "Feijão preto cozido", 5.5, 1.0 },
                    { 3, 143.0, 0.0, 0.0, 1.2, "Carne de frango grelhada", 31.0, 70.0 },
                    { 4, 250.0, 0.0, 0.0, 7.7000000000000002, "Carne bovina magra grelhada", 36.0, 60.0 },
                    { 5, 100.0, 1.0, 0.0, 1.0, "Peito de peru defumado", 21.0, 830.0 },
                    { 6, 70.0, 0.59999999999999998, 0.0, 5.0, "Ovo cozido", 6.5, 70.0 },
                    { 7, 66.0, 4.7000000000000002, 0.0, 3.6000000000000001, "Leite integral", 3.2999999999999998, 42.0 },
                    { 8, 333.0, 0.69999999999999996, 0.0, 25.100000000000001, "Queijo prato", 24.600000000000001, 618.0 },
                    { 9, 265.0, 48.0, 2.3999999999999999, 3.3999999999999999, "Pão francês", 8.5999999999999996, 457.0 },
                    { 10, 717.0, 0.0, 0.0, 81.099999999999994, "Manteiga", 0.5, 2.0 },
                    { 11, 828.0, 0.0, 0.0, 91.599999999999994, "Azeite de oliva", 0.0, 2.0 },
                    { 12, 82.0, 18.5, 1.8, 0.10000000000000001, "Batata inglesa cozida", 2.0, 2.0 },
                    { 13, 18.0, 3.8999999999999999, 1.2, 0.20000000000000001, "Tomate", 0.90000000000000002, 5.0 },
                    { 14, 15.0, 2.8999999999999999, 1.3, 0.20000000000000001, "Alface", 1.1000000000000001, 11.0 },
                    { 15, 35.0, 8.1999999999999993, 2.7999999999999998, 0.20000000000000001, "Cenoura crua", 0.80000000000000004, 69.0 },
                    { 16, 105.0, 27.0, 3.1000000000000001, 0.29999999999999999, "Banana", 1.3, 1.0 },
                    { 17, 52.0, 14.0, 2.3999999999999999, 0.5, "Maçã", 0.29999999999999999, 1.0 },
                    { 18, 47.0, 12.0, 2.3999999999999999, 0.20000000000000001, "Laranja", 1.2, 0.0 },
                    { 19, 43.0, 11.0, 1.7, 0.10000000000000001, "Mamão", 0.5, 8.0 },
                    { 20, 52.0, 13.1, 1.3999999999999999, 0.10000000000000001, "Abacaxi", 0.5, 2.0 },
                    { 21, 30.0, 7.5999999999999996, 0.40000000000000002, 0.20000000000000001, "Melancia", 0.59999999999999998, 1.0 },
                    { 22, 19.0, 3.7000000000000002, 1.1000000000000001, 0.20000000000000001, "Água de coco", 0.69999999999999996, 23.0 },
                    { 23, 39.0, 8.1999999999999993, 0.5, 0.20000000000000001, "Suco de laranja natural", 0.59999999999999998, 0.0 },
                    { 24, 2.0, 0.0, 0.0, 0.20000000000000001, "Café preto sem açúcar", 0.5, 2.0 },
                    { 25, 1.0, 0.0, 0.0, 0.0, "Chá verde sem açúcar", 0.0, 0.0 },
                    { 26, 48.0, 3.6000000000000001, 0.0, 0.10000000000000001, "Iogurte natural desnatado", 4.4000000000000004, 39.0 },
                    { 27, 290.0, 1.5, 0.0, 20.800000000000001, "Queijo minas frescal", 13.4, 594.0 },
                    { 28, 165.0, 0.0, 0.0, 3.6000000000000001, "Peito de frango cozido", 31.0, 74.0 },
                    { 29, 127.0, 19.199999999999999, 6.5999999999999996, 0.69999999999999996, "Feijão carioca cozido", 8.4000000000000004, 6.0 },
                    { 30, 23.0, 3.6000000000000001, 2.2000000000000002, 0.40000000000000002, "Espinafre cozido", 2.8999999999999999, 24.0 },
                    { 31, 17.0, 3.6000000000000001, 1.3, 0.29999999999999999, "Abobrinha cozida", 1.2, 1.0 },
                    { 32, 25.0, 5.9000000000000004, 3.0, 0.20000000000000001, "Berinjela cozida", 1.0, 1.0 },
                    { 33, 26.0, 6.2000000000000002, 1.0, 0.10000000000000001, "Abóbora cozida", 1.0, 1.0 },
                    { 34, 34.0, 6.5999999999999996, 2.6000000000000001, 0.59999999999999998, "Brócolis cozido", 2.7999999999999998, 33.0 },
                    { 35, 16.0, 3.6000000000000001, 0.5, 0.10000000000000001, "Pepino", 0.69999999999999996, 2.0 },
                    { 36, 25.0, 4.9000000000000004, 2.0, 0.29999999999999999, "Couve-flor cozida", 1.8999999999999999, 30.0 },
                    { 37, 680.0, 3.2999999999999998, 0.0, 77.599999999999994, "Maionese", 0.5, 620.0 },
                    { 38, 25.0, 6.0999999999999996, 2.5, 0.10000000000000001, "Repolho cru", 1.3, 18.0 },
                    { 39, 41.0, 6.9000000000000004, 2.7999999999999998, 0.20000000000000001, "Cenoura cozida", 0.90000000000000002, 69.0 },
                    { 40, 259.0, 0.0, 0.0, 10.6, "Bife grelhado", 26.600000000000001, 60.0 },
                    { 41, 132.0, 0.0, 0.0, 0.69999999999999996, "Atum em lata", 23.5, 360.0 },
                    { 42, 86.0, 20.100000000000001, 3.0, 0.10000000000000001, "Batata doce cozida", 1.6000000000000001, 4.0 },
                    { 43, 111.0, 23.199999999999999, 1.8, 1.3999999999999999, "Arroz integral cozido", 2.6000000000000001, 5.0 },
                    { 44, 120.0, 21.300000000000001, 2.7999999999999998, 3.6000000000000001, "Quinoa cozida", 4.0999999999999996, 7.0 },
                    { 45, 389.0, 66.299999999999997, 10.6, 6.9000000000000004, "Aveia", 11.9, 2.0 },
                    { 46, 158.0, 31.0, 3.2999999999999998, 1.5, "Macarrão integral cozido", 5.7999999999999998, 2.0 },
                    { 47, 98.0, 26.300000000000001, 0.0, 0.29999999999999999, "Tapioca", 0.10000000000000001, 1.0 },
                    { 48, 312.0, 35.399999999999999, 3.0, 19.199999999999999, "Batata frita", 3.3999999999999999, 320.0 },
                    { 49, 207.0, 21.100000000000001, 0.0, 6.7000000000000002, "Sorvete de creme", 2.7000000000000002, 45.0 },
                    { 50, 506.0, 57.700000000000003, 2.3999999999999999, 24.600000000000001, "Biscoito recheado", 4.2000000000000002, 400.0 },
                    { 51, 453.0, 55.399999999999999, 6.2999999999999998, 28.399999999999999, "Pipoca de micro-ondas", 8.0999999999999996, 1.0 },
                    { 52, 535.0, 59.700000000000003, 7.5, 30.899999999999999, "Chocolate ao leite", 6.9000000000000004, 16.0 },
                    { 53, 52.0, 13.800000000000001, 2.1000000000000001, 0.29999999999999999, "Maçã verde", 0.29999999999999999, 1.0 },
                    { 54, 69.0, 17.199999999999999, 0.90000000000000002, 0.20000000000000001, "Uva", 0.59999999999999998, 1.0 },
                    { 55, 32.0, 6.7000000000000002, 1.6000000000000001, 0.40000000000000002, "Morango", 0.80000000000000004, 1.0 },
                    { 56, 60.0, 14.800000000000001, 1.6000000000000001, 0.29999999999999999, "Manga", 0.59999999999999998, 1.0 },
                    { 57, 61.0, 15.199999999999999, 3.1000000000000001, 0.20000000000000001, "Pera", 0.40000000000000002, 1.0 },
                    { 58, 37.0, 9.4000000000000004, 0.59999999999999998, 0.20000000000000001, "Melão", 0.59999999999999998, 2.0 },
                    { 59, 61.0, 14.699999999999999, 2.5, 0.59999999999999998, "Kiwi", 1.1000000000000001, 3.0 },
                    { 60, 367.0, 77.0, 13.0, 0.40000000000000002, "Goji berry", 12.0, 3.0 },
                    { 61, 655.0, 12.9, 5.0, 66.400000000000006, "Castanha-do-pará", 14.300000000000001, 0.0 },
                    { 62, 575.0, 21.100000000000001, 12.5, 49.399999999999999, "Amêndoa", 21.199999999999999, 0.0 },
                    { 63, 650.0, 16.100000000000001, 9.6999999999999993, 61.399999999999999, "Avelã", 14.9, 0.0 },
                    { 64, 654.0, 13.0, 6.7000000000000002, 65.200000000000003, "Nozes", 14.0, 0.0 },
                    { 65, 562.0, 27.699999999999999, 10.6, 45.399999999999999, "Pistache", 20.899999999999999, 0.0 },
                    { 66, 574.0, 10.0, 6.0, 45.799999999999997, "Semente de abóbora", 29.800000000000001, 0.0 },
                    { 67, 582.0, 20.0, 8.5999999999999996, 51.5, "Semente de girassol", 19.300000000000001, 0.0 },
                    { 68, 235.0, 19.399999999999999, 0.90000000000000002, 12.800000000000001, "Pão de queijo", 3.2000000000000002, 384.0 }
                });

            migrationBuilder.InsertData(
                table: "TB_OBJETIVO",
                columns: new[] { "IdObjetivo", "DsObjetivo", "IdUsuario", "TipoObjetivo" },
                values: new object[,]
                {
                    { 1, "Manutenção da Saúde Geral", 1, 1 },
                    { 2, "Ganho de Massa Muscular", 1, 2 },
                    { 3, "Melhoria da Saúde Digestiva", 1, 3 },
                    { 4, "Perda de Peso", 1, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ALIMENTO");

            migrationBuilder.DropTable(
                name: "TB_OBJETIVO");
        }
    }
}
