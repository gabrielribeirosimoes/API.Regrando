using System;

namespace regrando.API.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }

        public string Cpf { get; set; }

        public string Nome { get; set; }

        public int Peso { get; set; }

        public double Altura { get; set; }

        public string Sexo { get; set; }

        public int Objetivo { get; set; }
    }
}
