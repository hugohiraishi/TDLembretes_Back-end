using System.ComponentModel.DataAnnotations;

namespace TDLembretes.DTO
{
    public class UsuarioDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        public string Telefone { get; set; }

    }
}
