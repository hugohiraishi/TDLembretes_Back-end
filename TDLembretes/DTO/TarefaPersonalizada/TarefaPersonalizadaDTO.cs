using TDLembretes.Models;

namespace TDLembretes.DTO.TarefaPersonalizada
{
    public class TarefaPersonalizadaDTO
    {
        public Usuario Usuario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public StatusTarefa Status { get; set; } 
        public PrioridadeTarefa Prioridade { get; set; }

    }
}
