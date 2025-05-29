using Microsoft.EntityFrameworkCore;
using TDLembretes.Models;
using TDLembretes.Repositories.Data;

namespace TDLembretes.Repositories
{
    public class UsuarioTarefasOficialRepository
    {

        private readonly tdlDbContext _context;

        public UsuarioTarefasOficialRepository(tdlDbContext context)
        {
            _context = context;
        }


        public async Task<bool> ExistsAsync(string usuarioId, string tarefaOficialId)
        {
            return await _context.UsuariosTarefasOficiais
                .AnyAsync(x => x.UsuarioId == usuarioId && x.TarefaOficialId == tarefaOficialId);
        }

        public async Task<TarefaOficial?> GetTarefaOficialAsync(string id)
        {
            return await _context.TarefasOficial.FindAsync(id);
        }

        public async Task CreateAsync(UsuarioTarefasOficiais usuarioTarefa)
        {
            _context.UsuariosTarefasOficiais.Add(usuarioTarefa);
            await _context.SaveChangesAsync();
        }

        public async Task<UsuarioTarefasOficiais?> GetUsuarioTarefaOficialAsync(string usuarioId, string tarefaOficialId)
        {
            return await _context.UsuariosTarefasOficiais
                .FirstOrDefaultAsync(x => x.UsuarioId == usuarioId && x.TarefaOficialId == tarefaOficialId);
        }

        public async Task UpdateAsync(UsuarioTarefasOficiais usuarioTarefa)
        {
            _context.UsuariosTarefasOficiais.Update(usuarioTarefa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UsuarioTarefasOficiais usuarioTarefa)
        {
            _context.UsuariosTarefasOficiais.Remove(usuarioTarefa);
            await _context.SaveChangesAsync();
        }


        public async Task<UsuarioTarefasOficiais?> GetByUsuarioETarefaAsync(string usuarioId, string tarefaOficialId)
        {
            return await _context.UsuariosTarefasOficiais
                .FirstOrDefaultAsync(x => x.UsuarioId == usuarioId && x.TarefaOficialId == tarefaOficialId);
        }


        public async Task<List<UsuarioTarefasOficiais>> GetByUsuarioAsync(string usuarioId)
        {
            return await _context.UsuariosTarefasOficiais
                .Where(x => x.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}
