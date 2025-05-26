using TDLembretes.Models;

namespace TDLembretes.DTO.TarefaOficial
{
    public class CriarTarefaOficialDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public int Pontos { get; set; }

    }
}
