using System;
using System.ComponentModel.DataAnnotations;

namespace regrando.API.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter exatamente 11 caracteres.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome deve ter entre 3 e 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Peso é obrigatório.")]
        [Range(1, 500, ErrorMessage = "O Peso deve estar entre 1 e 500.")]
        public int Peso { get; set; }

        [Required(ErrorMessage = "A Altura é obrigatória.")]
        [Range(0.1, 3.0, ErrorMessage = "A Altura deve estar entre 0.1 e 3.0 metros.")]
        public double Altura { get; set; }

        [Required(ErrorMessage = "O Sexo é obrigatório.")]
        [RegularExpression("^(M|F)$", ErrorMessage = "Sexo inválido. Use 'M' para masculino ou 'F' para feminino.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O Objetivo é obrigatório.")]
        [Range(1, 3, ErrorMessage = "O Objetivo deve estar entre 1 e 3.")]
        public int Objetivo { get; set; }

        // Propriedade de navegação para Cadastro
        public Cadastro Cadastro { get; set; }

    }
}
