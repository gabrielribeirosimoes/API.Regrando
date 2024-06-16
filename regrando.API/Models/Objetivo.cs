using regrando.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace regrando.API.Models
{
    public partial class Objetivo
    {
        [Key]
        public int IdObjetivo { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string DsObjetivo { get; set; }

        [Required]
        public TipoObjetivo TipoObjetivo { get; set; }
    }
}
