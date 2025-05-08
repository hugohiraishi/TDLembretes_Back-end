using TDLembretes.Models;

namespace TDLembretes.DTO
{
    public class AtualizarTarefaOficialDTO
    {
            
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public PrioridadeTarefa Prioridade { get; set; }
        public string ComprovacaoUrl { get; set; } = string.Empty;
        public DateTime DataFinalizacao { get; set; }



    }
}
