using TDLembretes.Models;

namespace TDLembretes.DTO
{
    public class TarefaOficialDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }
        public DateTime DataFinalizacao { get; set; }

    }
}
