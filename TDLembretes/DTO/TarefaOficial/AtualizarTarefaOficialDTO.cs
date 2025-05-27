using TDLembretes.Models;

namespace TDLembretes.DTO.TarefaOficial
{
    public class AtualizarTarefaOficialDTO
    {
            
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public PrioridadeTarefa Prioridade { get; set; }
        public DateTime DataFinalizacao { get; set; }

    }
}
