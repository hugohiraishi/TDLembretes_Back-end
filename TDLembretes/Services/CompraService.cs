namespace TDLembretes.Services
{
    public class CompraService
    {
        private readonly UsuarioService _usuarioService;
        private readonly ProdutoService _produtoService;

        public CompraService(UsuarioService usuarioService, ProdutoService produtoService)
        {
            _usuarioService = usuarioService;
            _produtoService = produtoService;
        }

        public async Task<bool> RealizarCompra(string usuarioId, string produtoId, int quantidade)
        {
            var usuario = await _usuarioService.GetUsuarioOrThrowException(usuarioId);
            var produto = await _produtoService.GetProdutoOrThrowException(produtoId);

            if (usuario == null || produto == null)
                throw new Exception("Usuário ou produto não encontrado.");

            if (produto.QuantidadeDisponivel <= 0)
                throw new Exception("Produto esgotado.");

            if (produto.QuantidadeDisponivel < quantidade)
                throw new Exception("Quantidade solicitada maior do que a disponível.");

            int custoTotal = produto.CustoEmPontos * quantidade;

            if (usuario.Pontos < custoTotal)
                throw new Exception("Pontos insuficientes para a compra.");

            usuario.Pontos -= custoTotal;
            await _usuarioService.UpdateUsuarioOrThrowException(usuario);

            produto.QuantidadeDisponivel -= quantidade;
            await _produtoService.UpdateProdutoOrThrowException(produto);

            return true;
        }

    }

}
