using TDLembretes.Repositories.Data;
using TDLembretes.Models;
using Microsoft.EntityFrameworkCore;

namespace TDLembretes.Repositories
{
    public class TarefaPersonalizadaRepository
    {

        private readonly tdlDbContext _context;

        public  TarefaPersonalizadaRepository(tdlDbContext context)
        {
            _context = context;
        }


        public async Task AddTarefaPersonalizada(TarefaPersonalizada tarefaPersonalizada)
        {

            await _context.TarefasPersonalizada.AddAsync(tarefaPersonalizada);
            await _context.SaveChangesAsync();

        }

        public async Task<List<TarefaPersonalizada>> GetTarefasPorUsuarioAsync(string usuarioId)
        {
            return await _context.TarefasPersonalizada
                .Where(t => t.UsuarioId == usuarioId)
                .ToListAsync();
        }



        public async Task<TarefaPersonalizada?> GetTarefaPersonalizada(string TarefaUsuarioId)
        {
            return await _context.TarefasPersonalizada.FirstOrDefaultAsync(t => t.Id == TarefaUsuarioId);
        }

        public async Task UpdateTarefaPersonalizada(TarefaPersonalizada tarefa)
        {
            _context.TarefasPersonalizada.Update(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTarefaPersonalizada(TarefaPersonalizada tarefa)
        {
            _context.TarefasPersonalizada.Remove(tarefa);
            await _context.SaveChangesAsync();
        }


    }
}
