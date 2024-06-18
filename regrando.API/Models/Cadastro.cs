using System.ComponentModel.DataAnnotations;

namespace regrando.API.Models
{
    public class Cadastro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O login é obrigatório.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 20 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Você deve aceitar os termos.")]
        public bool AceitouTermos { get; set; }

        // Chave estrangeira para Usuario
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
