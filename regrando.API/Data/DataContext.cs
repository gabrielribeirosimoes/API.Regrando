using Microsoft.EntityFrameworkCore;
using regrando.API.Models;
using regrando.API.Models.Enums;


namespace regrando.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Refeicoes> TB_REFEICOES { get; set; }
        public DbSet<Aguas> TB_AGUAS { get; set; }
        public DbSet<Usuario> TB_USUARIO { get; set; }
        public DbSet<Objetivo> TB_OBJETIVO { get; set; }
        public DbSet<Alimento> TB_ALIMENTO { get; set; }
        public DbSet<Receita> TB_RECEITA { get; set; }
        public DbSet<Cadastro> TB_CADASTRO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando a entidade Refeicoes
            modelBuilder.Entity<Usuario>()
               .HasKey(u => u.IdUsuario);

            modelBuilder.Entity<Refeicoes>()
                .HasKey(r => r.IdRefeicao);

            modelBuilder.Entity<Refeicoes>()
                .HasOne(r => r.Usuario)         // Uma refeição pertence a um usuário
                .WithMany(u => u.Refeicoes)     // Um usuário pode ter várias refeições
                .HasForeignKey(r => r.IdUsuario)
                .IsRequired();

            // Configuração de dados iniciais para Refeicoes
            modelBuilder.Entity<Refeicoes>().HasData(
                new Refeicoes() { IdRefeicao = 1, IdUsuario = 1, IdAlimento = 1, TpRefeicao = "Almoço", HrRefeicao = TimeSpan.FromHours(12) },
                new Refeicoes() { IdRefeicao = 2, IdUsuario = 2, IdAlimento = 2, TpRefeicao = "Jantar", HrRefeicao = TimeSpan.FromHours(19) }
                // Adicione mais refeições conforme necessário
            );

            // Configurando a entidade Aguas
            modelBuilder.Entity<Aguas>()
                .HasKey(e => e.IdAgua);

            modelBuilder.Entity<Aguas>().HasData(
                new Aguas() { IdAgua = 1, HrAgua = TimeSpan.FromHours(8), QtdAgua = 200 },
                new Aguas() { IdAgua = 2, HrAgua = TimeSpan.FromHours(12), QtdAgua = 300 }
            );

            // Configurando a entidade Cadastro
            modelBuilder.Entity<Cadastro>()
               .HasKey(c => c.Id);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.IdUsuario);

            // Relacionamento um-para-um entre Cadastro e Usuario
            modelBuilder.Entity<Cadastro>()
                .HasOne(c => c.Usuario)
                .WithOne(u => u.Cadastro)
                .HasForeignKey<Cadastro>(c => c.UsuarioId);

            // Configurando a entidade Usuario
            modelBuilder.Entity<Usuario>()
                .HasKey(e => e.IdUsuario);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.IdUsuario)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario() { IdUsuario = 1, Cpf = "123456789", Nome = "Exemplo", Peso = 70, Altura = 1.75, Sexo = "Masculino", Objetivo = 1 }
            );

            //modelBuilder.Entity<Objetivo>().ToTable("TB_OBJETIVO");
            modelBuilder.Entity<Objetivo>().HasKey(o => o.IdObjetivo);
            modelBuilder.Entity<Objetivo>().HasIndex(o => o.IdUsuario).IsUnique();

            modelBuilder.Entity<Objetivo>().HasData(
                new Objetivo { IdObjetivo = 1, IdUsuario = 1, DsObjetivo = "Manutenção da Saúde Geral", TipoObjetivo = TipoObjetivo.ManutencaoSaudeGeral },
                new Objetivo { IdObjetivo = 2, IdUsuario = 2, DsObjetivo = "Ganho de Massa Muscular", TipoObjetivo = TipoObjetivo.GanhoMassaMuscular },
                new Objetivo { IdObjetivo = 3, IdUsuario = 3, DsObjetivo = "Melhoria da Saúde Digestiva", TipoObjetivo = TipoObjetivo.MelhoriaSaudeDigestiva },
                new Objetivo { IdObjetivo = 4, IdUsuario = 4, DsObjetivo = "Perda de Peso", TipoObjetivo = TipoObjetivo.PerdaPeso }
            );

            modelBuilder.Entity<Receita>().HasKey(r => r.IdReceita);

            modelBuilder.Entity<Receita>().HasData(
                new Receita
                {
                    IdReceita = 1,
                    NomeReceita = "Bolo de cenoura",
                    Descricao = "Delicioso bolo de cenoura com cobertura de chocolate",
                    Ingredientes = "Cenoura, óleo, ovos, açúcar, farinha de trigo, fermento em pó, chocolate",
                    ModoPreparo = "1. Bata no liquidificador as cenouras, óleo e ovos. 2. Adicione o açúcar e a farinha de trigo. 3. Por último, coloque o fermento e misture delicadamente. 4. Asse em forno médio por aproximadamente 40 minutos.",
                    Calorias = 200,
                    TempoPreparoMinutos = 40
                },
                new Receita
                {
                    IdReceita = 2,
                    NomeReceita = "Salada de quinoa",
                    Descricao = "Salada refrescante com quinoa, tomate, pepino e temperos",
                    Ingredientes = "Quinoa, tomate, pepino, azeite, limão, sal",
                    ModoPreparo = "1. Cozinhe a quinoa conforme as instruções da embalagem. 2. Corte os tomates e pepinos em cubos. 3. Misture tudo e tempere a gosto. 4. Sirva frio.",
                    Calorias = 150,
                    TempoPreparoMinutos = 30
                }
               );

            modelBuilder.Entity<Alimento>().HasKey(a => a.IdAlimento);

            modelBuilder.Entity<Alimento>().HasData(
                new Alimento { IdAlimento = 1, NomeAlimento = "Arroz branco cozido", Carboidratos = 25.8, Gorduras = 0.3, Proteinas = 2.6, Calorias = 124, Fibras = 0.4, Sodio = 1 },
                new Alimento { IdAlimento = 2, NomeAlimento = "Feijão preto cozido", Carboidratos = 14.5, Gorduras = 0.5, Proteinas = 5.5, Calorias = 77, Fibras = 6.4, Sodio = 1 },
                new Alimento { IdAlimento = 3, NomeAlimento = "Carne de frango grelhada", Carboidratos = 0, Gorduras = 1.2, Proteinas = 31, Calorias = 143, Fibras = 0, Sodio = 70 },
                new Alimento { IdAlimento = 4, NomeAlimento = "Carne bovina magra grelhada", Carboidratos = 0, Gorduras = 7.7, Proteinas = 36, Calorias = 250, Fibras = 0, Sodio = 60 },
                new Alimento { IdAlimento = 5, NomeAlimento = "Peito de peru defumado", Carboidratos = 1, Gorduras = 1, Proteinas = 21, Calorias = 100, Fibras = 0, Sodio = 830 },
                new Alimento { IdAlimento = 6, NomeAlimento = "Ovo cozido", Carboidratos = 0.6, Gorduras = 5, Proteinas = 6.5, Calorias = 70, Fibras = 0, Sodio = 70 },
                new Alimento { IdAlimento = 7, NomeAlimento = "Leite integral", Carboidratos = 4.7, Gorduras = 3.6, Proteinas = 3.3, Calorias = 66, Fibras = 0, Sodio = 42 },
                new Alimento { IdAlimento = 8, NomeAlimento = "Queijo prato", Carboidratos = 0.7, Gorduras = 25.1, Proteinas = 24.6, Calorias = 333, Fibras = 0, Sodio = 618 },
                new Alimento { IdAlimento = 9, NomeAlimento = "Pão francês", Carboidratos = 48, Gorduras = 3.4, Proteinas = 8.6, Calorias = 265, Fibras = 2.4, Sodio = 457 },
                new Alimento { IdAlimento = 10, NomeAlimento = "Manteiga", Carboidratos = 0, Gorduras = 81.1, Proteinas = 0.5, Calorias = 717, Fibras = 0, Sodio = 2 },
                new Alimento { IdAlimento = 11, NomeAlimento = "Azeite de oliva", Carboidratos = 0, Gorduras = 91.6, Proteinas = 0, Calorias = 828, Fibras = 0, Sodio = 2 },
                new Alimento { IdAlimento = 12, NomeAlimento = "Batata inglesa cozida", Carboidratos = 18.5, Gorduras = 0.1, Proteinas = 2, Calorias = 82, Fibras = 1.8, Sodio = 2 },
                new Alimento { IdAlimento = 13, NomeAlimento = "Tomate", Carboidratos = 3.9, Gorduras = 0.2, Proteinas = 0.9, Calorias = 18, Fibras = 1.2, Sodio = 5 },
                new Alimento { IdAlimento = 14, NomeAlimento = "Alface", Carboidratos = 2.9, Gorduras = 0.2, Proteinas = 1.1, Calorias = 15, Fibras = 1.3, Sodio = 11 },
                new Alimento { IdAlimento = 15, NomeAlimento = "Cenoura crua", Carboidratos = 8.2, Gorduras = 0.2, Proteinas = 0.8, Calorias = 35, Fibras = 2.8, Sodio = 69 },
                new Alimento { IdAlimento = 16, NomeAlimento = "Banana", Carboidratos = 27, Gorduras = 0.3, Proteinas = 1.3, Calorias = 105, Fibras = 3.1, Sodio = 1 },
                new Alimento { IdAlimento = 17, NomeAlimento = "Maçã", Carboidratos = 14, Gorduras = 0.5, Proteinas = 0.3, Calorias = 52, Fibras = 2.4, Sodio = 1 },
                new Alimento { IdAlimento = 18, NomeAlimento = "Laranja", Carboidratos = 12, Gorduras = 0.2, Proteinas = 1.2, Calorias = 47, Fibras = 2.4, Sodio = 0 },
                new Alimento { IdAlimento = 19, NomeAlimento = "Mamão", Carboidratos = 11, Gorduras = 0.1, Proteinas = 0.5, Calorias = 43, Fibras = 1.7, Sodio = 8 },
                new Alimento { IdAlimento = 20, NomeAlimento = "Abacaxi", Carboidratos = 13.1, Gorduras = 0.1, Proteinas = 0.5, Calorias = 52, Fibras = 1.4, Sodio = 2 },
                new Alimento { IdAlimento = 21, NomeAlimento = "Melancia", Carboidratos = 7.6, Gorduras = 0.2, Proteinas = 0.6, Calorias = 30, Fibras = 0.4, Sodio = 1 },
                new Alimento { IdAlimento = 22, NomeAlimento = "Água de coco", Carboidratos = 3.7, Gorduras = 0.2, Proteinas = 0.7, Calorias = 19, Fibras = 1.1, Sodio = 23 },
                new Alimento { IdAlimento = 23, NomeAlimento = "Suco de laranja natural", Carboidratos = 8.2, Gorduras = 0.2, Proteinas = 0.6, Calorias = 39, Fibras = 0.5, Sodio = 0 },
                new Alimento { IdAlimento = 24, NomeAlimento = "Café preto sem açúcar", Carboidratos = 0, Gorduras = 0.2, Proteinas = 0.5, Calorias = 2, Fibras = 0, Sodio = 2 },
                new Alimento { IdAlimento = 25, NomeAlimento = "Chá verde sem açúcar", Carboidratos = 0, Gorduras = 0, Proteinas = 0, Calorias = 1, Fibras = 0, Sodio = 0 },
                new Alimento { IdAlimento = 26, NomeAlimento = "Iogurte natural desnatado", Carboidratos = 3.6, Gorduras = 0.1, Proteinas = 4.4, Calorias = 48, Fibras = 0, Sodio = 39 },
                new Alimento { IdAlimento = 27, NomeAlimento = "Queijo minas frescal", Carboidratos = 1.5, Gorduras = 20.8, Proteinas = 13.4, Calorias = 290, Fibras = 0, Sodio = 594 },
                new Alimento { IdAlimento = 28, NomeAlimento = "Peito de frango cozido", Carboidratos = 0, Gorduras = 3.6, Proteinas = 31, Calorias = 165, Fibras = 0, Sodio = 74 },
                new Alimento { IdAlimento = 29, NomeAlimento = "Feijão carioca cozido", Carboidratos = 19.2, Gorduras = 0.7, Proteinas = 8.4, Calorias = 127, Fibras = 6.6, Sodio = 6 },
                new Alimento { IdAlimento = 30, NomeAlimento = "Espinafre cozido", Carboidratos = 3.6, Gorduras = 0.4, Proteinas = 2.9, Calorias = 23, Fibras = 2.2, Sodio = 24 },
                new Alimento { IdAlimento = 31, NomeAlimento = "Abobrinha cozida", Carboidratos = 3.6, Gorduras = 0.3, Proteinas = 1.2, Calorias = 17, Fibras = 1.3, Sodio = 1 },
                new Alimento { IdAlimento = 32, NomeAlimento = "Berinjela cozida", Carboidratos = 5.9, Gorduras = 0.2, Proteinas = 1.0, Calorias = 25, Fibras = 3.0, Sodio = 1 },
                new Alimento { IdAlimento = 33, NomeAlimento = "Abóbora cozida", Carboidratos = 6.2, Gorduras = 0.1, Proteinas = 1.0, Calorias = 26, Fibras = 1.0, Sodio = 1 },
                new Alimento { IdAlimento = 34, NomeAlimento = "Brócolis cozido", Carboidratos = 6.6, Gorduras = 0.6, Proteinas = 2.8, Calorias = 34, Fibras = 2.6, Sodio = 33 },
                new Alimento { IdAlimento = 35, NomeAlimento = "Pepino", Carboidratos = 3.6, Gorduras = 0.1, Proteinas = 0.7, Calorias = 16, Fibras = 0.5, Sodio = 2 },
                new Alimento { IdAlimento = 36, NomeAlimento = "Couve-flor cozida", Carboidratos = 4.9, Gorduras = 0.3, Proteinas = 1.9, Calorias = 25, Fibras = 2.0, Sodio = 30 },
                new Alimento { IdAlimento = 37, NomeAlimento = "Maionese", Carboidratos = 3.3, Gorduras = 77.6, Proteinas = 0.5, Calorias = 680, Fibras = 0, Sodio = 620 },
                new Alimento { IdAlimento = 38, NomeAlimento = "Repolho cru", Carboidratos = 6.1, Gorduras = 0.1, Proteinas = 1.3, Calorias = 25, Fibras = 2.5, Sodio = 18 },
                new Alimento { IdAlimento = 39, NomeAlimento = "Cenoura cozida", Carboidratos = 6.9, Gorduras = 0.2, Proteinas = 0.9, Calorias = 41, Fibras = 2.8, Sodio = 69 },
                new Alimento { IdAlimento = 40, NomeAlimento = "Bife grelhado", Carboidratos = 0, Gorduras = 10.6, Proteinas = 26.6, Calorias = 259, Fibras = 0, Sodio = 60 },
                new Alimento { IdAlimento = 41, NomeAlimento = "Atum em lata", Carboidratos = 0, Gorduras = 0.7, Proteinas = 23.5, Calorias = 132, Fibras = 0, Sodio = 360 },
                new Alimento { IdAlimento = 42, NomeAlimento = "Batata doce cozida", Carboidratos = 20.1, Gorduras = 0.1, Proteinas = 1.6, Calorias = 86, Fibras = 3.0, Sodio = 4 },
                new Alimento { IdAlimento = 43, NomeAlimento = "Arroz integral cozido", Carboidratos = 23.2, Gorduras = 1.4, Proteinas = 2.6, Calorias = 111, Fibras = 1.8, Sodio = 5 },
                new Alimento { IdAlimento = 44, NomeAlimento = "Quinoa cozida", Carboidratos = 21.3, Gorduras = 3.6, Proteinas = 4.1, Calorias = 120, Fibras = 2.8, Sodio = 7 },
                new Alimento { IdAlimento = 45, NomeAlimento = "Aveia", Carboidratos = 66.3, Gorduras = 6.9, Proteinas = 11.9, Calorias = 389, Fibras = 10.6, Sodio = 2 },
                new Alimento { IdAlimento = 46, NomeAlimento = "Macarrão integral cozido", Carboidratos = 31, Gorduras = 1.5, Proteinas = 5.8, Calorias = 158, Fibras = 3.3, Sodio = 2 },
                new Alimento { IdAlimento = 47, NomeAlimento = "Tapioca", Carboidratos = 26.3, Gorduras = 0.3, Proteinas = 0.1, Calorias = 98, Fibras = 0, Sodio = 1 },
                new Alimento { IdAlimento = 48, NomeAlimento = "Batata frita", Carboidratos = 35.4, Gorduras = 19.2, Proteinas = 3.4, Calorias = 312, Fibras = 3.0, Sodio = 320 },
                new Alimento { IdAlimento = 49, NomeAlimento = "Sorvete de creme", Carboidratos = 21.1, Gorduras = 6.7, Proteinas = 2.7, Calorias = 207, Fibras = 0, Sodio = 45 },
                new Alimento { IdAlimento = 50, NomeAlimento = "Biscoito recheado", Carboidratos = 57.7, Gorduras = 24.6, Proteinas = 4.2, Calorias = 506, Fibras = 2.4, Sodio = 400 },
                new Alimento { IdAlimento = 51, NomeAlimento = "Pipoca de micro-ondas", Carboidratos = 55.4, Gorduras = 28.4, Proteinas = 8.1, Calorias = 453, Fibras = 6.3, Sodio = 1 },
                new Alimento { IdAlimento = 52, NomeAlimento = "Chocolate ao leite", Carboidratos = 59.7, Gorduras = 30.9, Proteinas = 6.9, Calorias = 535, Fibras = 7.5, Sodio = 16 },
                new Alimento { IdAlimento = 53, NomeAlimento = "Maçã verde", Carboidratos = 13.8, Gorduras = 0.3, Proteinas = 0.3, Calorias = 52, Fibras = 2.1, Sodio = 1 },
                new Alimento { IdAlimento = 54, NomeAlimento = "Uva", Carboidratos = 17.2, Gorduras = 0.2, Proteinas = 0.6, Calorias = 69, Fibras = 0.9, Sodio = 1 },
                new Alimento { IdAlimento = 55, NomeAlimento = "Morango", Carboidratos = 6.7, Gorduras = 0.4, Proteinas = 0.8, Calorias = 32, Fibras = 1.6, Sodio = 1 },
                new Alimento { IdAlimento = 56, NomeAlimento = "Manga", Carboidratos = 14.8, Gorduras = 0.3, Proteinas = 0.6, Calorias = 60, Fibras = 1.6, Sodio = 1 },
                new Alimento { IdAlimento = 57, NomeAlimento = "Pera", Carboidratos = 15.2, Gorduras = 0.2, Proteinas = 0.4, Calorias = 61, Fibras = 3.1, Sodio = 1 },
                new Alimento { IdAlimento = 58, NomeAlimento = "Melão", Carboidratos = 9.4, Gorduras = 0.2, Proteinas = 0.6, Calorias = 37, Fibras = 0.6, Sodio = 2 },
                new Alimento { IdAlimento = 59, NomeAlimento = "Kiwi", Carboidratos = 14.7, Gorduras = 0.6, Proteinas = 1.1, Calorias = 61, Fibras = 2.5, Sodio = 3 },
                new Alimento { IdAlimento = 60, NomeAlimento = "Goji berry", Carboidratos = 77.0, Gorduras = 0.4, Proteinas = 12.0, Calorias = 367, Fibras = 13.0, Sodio = 3 },
                new Alimento { IdAlimento = 61, NomeAlimento = "Castanha-do-pará", Carboidratos = 12.9, Gorduras = 66.4, Proteinas = 14.3, Calorias = 655, Fibras = 5.0, Sodio = 0 },
                new Alimento { IdAlimento = 62, NomeAlimento = "Amêndoa", Carboidratos = 21.1, Gorduras = 49.4, Proteinas = 21.2, Calorias = 575, Fibras = 12.5, Sodio = 0 },
                new Alimento { IdAlimento = 63, NomeAlimento = "Avelã", Carboidratos = 16.1, Gorduras = 61.4, Proteinas = 14.9, Calorias = 650, Fibras = 9.7, Sodio = 0 },
                new Alimento { IdAlimento = 64, NomeAlimento = "Nozes", Carboidratos = 13.0, Gorduras = 65.2, Proteinas = 14.0, Calorias = 654, Fibras = 6.7, Sodio = 0 },
                new Alimento { IdAlimento = 65, NomeAlimento = "Pistache", Carboidratos = 27.7, Gorduras = 45.4, Proteinas = 20.9, Calorias = 562, Fibras = 10.6, Sodio = 0 },
                new Alimento { IdAlimento = 66, NomeAlimento = "Semente de abóbora", Carboidratos = 10.0, Gorduras = 45.8, Proteinas = 29.8, Calorias = 574, Fibras = 6.0, Sodio = 0 },
                new Alimento { IdAlimento = 67, NomeAlimento = "Semente de girassol", Carboidratos = 20.0, Gorduras = 51.5, Proteinas = 19.3, Calorias = 582, Fibras = 8.6, Sodio = 0 },
                new Alimento { IdAlimento = 68, NomeAlimento = "Pão de queijo", Carboidratos = 19.4, Gorduras = 12.8, Proteinas = 3.2, Calorias = 235, Fibras = 0.9, Sodio = 384 }
            );
        }


            protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
            {
                configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(200);
            }

    }
}
