using TDLembretes.Repositories;
using TDLembretes.Models;
using Microsoft.JSInterop.Infrastructure;
using TDLembretes.DTO.Usuarios;
using TDLembretes.DTO.Produto;

namespace TDLembretes.Services
{
    public class UsuarioService
    {

        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

       
        //PUT atributos
        public async Task AtualizarUsuario(string id, UsuarioDTO dto)
        {
            Usuario? usuario = await _usuarioRepository.GetUsuario(id);

            if (usuario == null)
                throw new Exception("Usuário não não encontrado!");

            usuario.Email = dto.Email;
            usuario.Telefone = dto.Telefone;
            usuario.Nome = dto.Nome;

            await _usuarioRepository.AtualizarUsuario(usuario);
        }

        //PUT senha

        public async Task AtualizarSenha(string id, AtualizarSenhaUsuarioDTO dto)
        {
            Usuario? usuario = await _usuarioRepository.GetUsuario(id);

            if (usuario == null)
                throw new Exception("Usuário não não encontrado!");

            if (usuario.Senha != dto.SenhaAtual)
                throw new Exception("Senha atual incorreta!");

            usuario.Senha = dto.NovaSenha;
            await _usuarioRepository.AtualizarUsuario(usuario);
        }

        //DELET
        public async Task DeletarUsuario(string id)
        {
            Usuario? usuario = await _usuarioRepository.GetUsuario(id);

            if (usuario == null)
                    throw new Exception("Usuario não encontrado!");

            await _usuarioRepository.DeleteUsuario(usuario);
        }

        //GET
        public async Task<UsuarioDTO> GetUsuarioDTO(string usuarioId)
        {
            var usuario = await GetUsuarioOrThrowException(usuarioId);

            return new UsuarioDTO
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
            };
        }

        public async Task<List<UsuarioDTO>> GetTodosUsuarios()
        {
            var usuarios = await _usuarioRepository.GetTodosUsuarios();

            return usuarios.Select(usuario => new UsuarioDTO
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
            }).ToList();
        }


        private async Task<Usuario?> GetUsuario(string UsuarioId)
        {
            Usuario? usuario = await _usuarioRepository.GetUsuario(UsuarioId);

            return usuario;
        }

        public async Task<Usuario> GetUsuarioOrThrowException(string UsuarioId)
        {
            Usuario? usuario = await GetUsuario(UsuarioId);
            if (usuario == null)
            {
                throw new Exception("Usuario não encontrado!");
            }

            return usuario;
        }

    }
}
