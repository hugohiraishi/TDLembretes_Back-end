using Microsoft.EntityFrameworkCore;
using TDLembretes.Models;
using TDLembretes.Repositories.Data;

namespace TDLembretes.Repositories
{
    public class UsuarioRepository
    {

        private readonly tdlDbContext _context;

        public UsuarioRepository(tdlDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetUsuario(string usuarioId)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarioId);
        }

        public async Task<List<Usuario>> GetTodosUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }


        public async Task AtualizarUsuario(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteUsuario(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
