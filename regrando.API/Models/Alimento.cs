using System;

namespace regrando.API.Models
{
    public partial class Alimento
    {
        public int IdAlimento { get; set; }
        public string NomeAlimento { get; set; }
        public double Carboidratos { get; set; }
        public double Gorduras { get; set; }
        public double Proteinas { get; set; }
        public double Calorias { get; set; }
        public double Fibras { get; set; }
        public double Sodio { get; set; }
    }
}
