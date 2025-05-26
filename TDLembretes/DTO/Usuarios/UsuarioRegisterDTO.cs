using System.ComponentModel.DataAnnotations;

namespace TDLembretes.DTO.Usuarios
{
    public class UsuarioRegisterDTO
    {
        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Telefone { get; set; }
        public string Senha { get; set; }

    }
}
