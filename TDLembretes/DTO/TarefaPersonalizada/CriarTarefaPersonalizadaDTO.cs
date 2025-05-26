using TDLembretes.Models;

namespace TDLembretes.DTO.TarefaPersonalizada
{
    public class CriarTarefaPersonalizadaDTO
    {

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }


    }
}
