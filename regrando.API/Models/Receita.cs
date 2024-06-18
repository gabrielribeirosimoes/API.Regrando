namespace regrando.API.Models
{
    public class Receita
    {
        public int IdReceita { get; set; }
        public string NomeReceita { get; set; }
        public string Descricao { get; set; }
        public string Ingredientes { get; set; }
        public string ModoPreparo { get; set; }
        public int Calorias { get; set; }
        public int TempoPreparoMinutos { get; set; }
    }
}
