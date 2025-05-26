using TDLembretes.Models;
using TDLembretes.Repositories.Data;
using Microsoft.EntityFrameworkCore;

namespace TDLembretes.Repositories
{
    public class TarefaOficialRepository
    {

        private readonly tdlDbContext _context;

        public TarefaOficialRepository(tdlDbContext context)
        {
            _context = context;
        }


        public async Task AddTarefaOficial(TarefaOficial tarefaOficial)
        {

            await _context.TarefasOficial.AddAsync(tarefaOficial);
            await _context.SaveChangesAsync();
            
        }
        public async Task<TarefaOficial?> GetTarefaOficial(string TarefaUsuarioId)
        {
            return await _context.TarefasOficial.FirstOrDefaultAsync(t => t.Id == TarefaUsuarioId);
        }
        public async Task<List<TarefaOficial>> GetTodasTarefasOficial()
        {
            return await _context.TarefasOficial.ToListAsync();
        }

        public async Task UpdateTarefaOficial(TarefaOficial tarefa)
        {
            _context.TarefasOficial.Update(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTarefaOficial(TarefaOficial tarefa)
        {
            _context.TarefasOficial.Remove(tarefa);
            await _context.SaveChangesAsync();
        }


    }
}
