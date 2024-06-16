using System;

namespace regrando.API.Models
{
    public class Objetivo
    {
        public int IdObjetivo { get; set; }

        public int IdUsuario { get; set; }

        public string DsObjetivo { get; set; }

        public int TipoObjetivo { get; set; }
    }
}
