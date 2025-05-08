namespace TDLembretes.Models
{
    public class Produto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CustoEmPontos { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public string ImagemUrl { get; set; }

        private Produto() { }

        public Produto(string id, string nome, string descricao, int custoEmPontos, int quantidadeDisponivel, string imagemUrl)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            CustoEmPontos = custoEmPontos;
            QuantidadeDisponivel = quantidadeDisponivel;
            ImagemUrl = imagemUrl;
        }
    }
}
