using TDLembretes.Models;

namespace TDLembretes.DTO.TarefaPersonalizada
{
    public class AtualizarTarefaPersonalizadaDTO
    {

        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataFinalizacao { get; set; }
        public StatusTarefa Status { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }
    }
}
