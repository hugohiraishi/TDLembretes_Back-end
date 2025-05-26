using Microsoft.EntityFrameworkCore;
using TDLembretes.Models;
using TDLembretes.Repositories.Data;

namespace TDLembretes.Repositories
{
    public class ProdutoRepository
    {

        private readonly tdlDbContext _context;

        public ProdutoRepository(tdlDbContext context)
        {
            _context = context;
        }


        public async Task AddProduto(Produto produto)
        {

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Produto>> GetTodosProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto?> GetProdutos(string ProdutoId)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == ProdutoId);
        }

        public async Task UpdateProduto(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProdutos(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

    }
}
