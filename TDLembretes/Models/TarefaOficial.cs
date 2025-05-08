using System.ComponentModel.DataAnnotations;

namespace TDLembretes.Models
{
    public class TarefaOficial
    {
        public string Id { get; set; }
        public string Titulo { get; set; }   
        public string Descricao { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }
        public int Pontos { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public string? ComprovacaoUrl { get; set; }  
        public StatusComprovacao StatusComprovacao { get; set; } = StatusComprovacao.AguardandoAprovacao;

        private TarefaOficial() { }

        public TarefaOficial(string id, string titulo, string descricao, PrioridadeTarefa prioridade,int pontos,DateTime dataCriacao, DateTime dataFinalizacao, string comprovacaoUrl, StatusComprovacao statusComprovacao)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Prioridade = prioridade;
            DataCriacao = dataCriacao;
            DataFinalizacao = dataFinalizacao;
            ComprovacaoUrl = comprovacaoUrl;
            StatusComprovacao = statusComprovacao;
        }

    }


    public enum StatusComprovacao
    {
        AguardandoAprovacao,  
        Aprovada,             
        Rejeitada             
    }

}
