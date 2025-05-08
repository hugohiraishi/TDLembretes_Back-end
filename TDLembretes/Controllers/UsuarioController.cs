using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDLembretes.Repositories.Data;
using TDLembretes.Models;
using TDLembretes.Services;
using System.Security.Cryptography.X509Certificates;
using TDLembretes.DTO;
using Microsoft.Extensions.FileProviders;

namespace TDLembretes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : ControllerBase
    {
        private readonly tdlDbContext _context;
        private readonly UsuarioService _usuarioService;

        public UsuarioController(tdlDbContext context, UsuarioService usuarioService)
        {
            _context = context;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
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