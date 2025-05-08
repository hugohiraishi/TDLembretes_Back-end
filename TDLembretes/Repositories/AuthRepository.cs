using TDLembretes.Repositories.Data;
using TDLembretes.Models;
using Microsoft.EntityFrameworkCore;

namespace TDLembretes.Repositories
{
    public class AuthRepository
    {
        private readonly tdlDbContext _context;

        public AuthRepository(tdlDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetUsuarioByEmailAndSenha(string email, string senha)
        {
            var emailNormalizado = email.Trim().ToLower();
            var senhaNormalizada = senha.Trim();

            Usuario? usuario = await _context.Usuarios
                .FirstOrDefaultAsync(p => p.Email.Trim().ToLower() == emailNormalizado);

            if (usuario != null && usuario.Senha.Trim() == senhaNormalizada)
            {
                return usuario;
            }

            return null;
        }


        public async Task<Usuario?> GetUsuarioByEmail(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

    }
}
