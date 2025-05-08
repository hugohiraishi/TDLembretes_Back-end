using TDLembretes.Repositories;
using TDLembretes.Models;
using TDLembretes.DTO;
using Microsoft.JSInterop.Infrastructure;

namespace TDLembretes.Services
{
    public class UsuarioService
    {

        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository pacienteRepository)
        {
            _usuarioRepository = pacienteRepository;
        }


        private async Task<Usuario?> GetUsuario(string usuarioId)
        {
            Usuario? usuario = await _usuarioRepository.GetUsuario(usuarioId);

            return usuario;
        }

        public async Task<Usuario> GetUsuarioOrThrowException(string usuarioId)
        {
            Usuario? usuario = await GetUsuario(usuarioId);
            if (usuario == null)
            {
                throw new Exception("Usuario não encontrado!");
            }

            return usuario;
        }

        public async Task AtualizarUsuario(string id, UsuarioDTO dto)
        {
            Usuario? usuario = await _usuarioRepository.GetUsuario(id);

            if (usuario == null)
                throw new Exception("Usuário não não encontrado!");

            usuario.Email = dto.Email;
            usuario.Telefone = dto.Telefone;
            usuario.Nome = dto.Nome;
            usuario.Senha = dto.Senha;

            await _usuarioRepository.AtualizarUsuario(usuario);
        }

        public async Task DeletarUsuario(string id)
        {
            Usuario? usuario = await _usuarioRepository.GetUsuario(id);

            if (usuario == null)
                    throw new Exception("Usuario não encontrado!");

            await _usuarioRepository.DeleteUsuario(usuario);
        }

    }
}
