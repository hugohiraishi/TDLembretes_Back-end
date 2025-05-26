using TDLembretes.Models;

namespace TDLembretes.DTO.TarefaOficial
{
    public class TarefaOficialDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }
        public int Pontos { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public string? ComprovacaoUrl { get; set; }
        public StatusTarefa Status { get; set; } 
        public StatusComprovacao StatusComprovacao { get; set; } 

    }
}
