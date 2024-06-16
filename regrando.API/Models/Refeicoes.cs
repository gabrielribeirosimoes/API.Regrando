using System;

namespace regrando.API.Models
{
    public partial class Refeicoes
    {
        public int IdRefeicao { get; set; }

        public int IdUsuario { get; set; }

        public int IdAlimento { get; set; }

        public string TpRefeicao { get; set; }

        public TimeSpan? HrRefeicao { get; set; }
    }
}
