using TDLembretes.DTO.Produto;
using TDLembretes.Models;
using TDLembretes.Repositories;
using TDLembretes.Repositories.Data;

namespace TDLembretes.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoService(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        
        //POST
        public async Task<string> CriarProduto(ProdutoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Nome) ||
                string.IsNullOrEmpty(dto.Descricao) ||
                string.IsNullOrEmpty(dto.ImagemUrl) ||
                dto.CustoEmPontos <= 0 ||
                dto.QuantidadeDisponivel <= 0)
            {
                throw new Exception("Dados inválidos para criar o produto.");
            }

            Produto novoProduto = new Produto (
                Guid.NewGuid().ToString(),
                dto.Nome,
                dto.Descricao,
                dto.CustoEmPontos,
                dto.QuantidadeDisponivel,
                dto.ImagemUrl
            );

            await _produtoRepository.AddProduto(novoProduto);
            return novoProduto.Id;

        }

        //PUT
        public async Task UpdateProduto(string id,ProdutoDTO dto)
        {
            Produto? produto = await _produtoRepository.GetProdutos(id);
            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produto.Nome = dto.Nome;
            produto.Descricao = dto.Descricao;
            produto.CustoEmPontos = dto.CustoEmPontos;
            produto.QuantidadeDisponivel = dto.QuantidadeDisponivel;
            produto.ImagemUrl = dto.ImagemUrl;

            await _produtoRepository.UpdateProduto(produto);
        }

        private async Task UpdateProduto(Produto produto)
        {
            await _produtoRepository.UpdateProduto(produto);
        }

        public async Task UpdateProdutoOrThrowException(Produto produto)
        {
            var existingProduto = await _produtoRepository.GetProdutos(produto.Id);
            if (existingProduto == null)
                throw new Exception("Produto não encontrado!");

            await UpdateProduto(produto);
        }

        //DELET
        public async Task DeleteProduto(string id)
        {
            Produto? produto = await _produtoRepository.GetProdutos(id);
            if (produto == null)
                throw new Exception("Produto não encontrado.");

            await _produtoRepository.DeleteProdutos(produto);
        }


        //GET
        public async Task<ProdutoDTO> GetProdutoDTO(string produtoId)
        {
            var produto = await GetProdutoOrThrowException(produtoId);

            return new ProdutoDTO
            {
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                ImagemUrl = produto.ImagemUrl,
                CustoEmPontos = produto.CustoEmPontos,
                QuantidadeDisponivel = produto.QuantidadeDisponivel
            };
        }

        public async Task<List<ProdutoDTO>> GetTodosProdutos()
        {
            var produtos = await _produtoRepository.GetTodosProdutos(); 

            return produtos.Select(produto => new ProdutoDTO
            {
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                ImagemUrl = produto.ImagemUrl,
                CustoEmPontos = produto.CustoEmPontos,
                QuantidadeDisponivel = produto.QuantidadeDisponivel
            }).ToList();
        }


        private async Task<Produto?> GetProduto(string ProdutoId)
        {
            Produto? produto = await _produtoRepository.GetProdutos(ProdutoId);

            return produto;
        }

        public async Task<Produto> GetProdutoOrThrowException(string produtolId)
        {
            Produto? produto = await GetProduto(produtolId);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado!");
            }

            return produto;
        }

    }
}
