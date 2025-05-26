using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDLembretes.Repositories.Data;
using TDLembretes.Models;
using TDLembretes.Services;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.FileProviders;
using TDLembretes.DTO.Usuarios;
using TDLembretes.DTO.Produto;

namespace TDLembretes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(tdlDbContext context, UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetTodos()
        {
            var produtos = await _usuarioService.GetTodosUsuarios();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> Get(string id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuarioDTO(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarUsuario(string id)
        {
            try
            {
                await _usuarioService.DeletarUsuario(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("senha")]
        public async Task<ActionResult> AtualizarSenha(string id, [FromBody] AtualizarSenhaUsuarioDTO dto)
        {
            try
            {
                await _usuarioService.AtualizarSenha(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarUsuario(string id, [FromBody] UsuarioDTO dto)
        {
            try
            {
                await _usuarioService.AtualizarUsuario(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}