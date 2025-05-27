using TDLembretes.Models;

namespace TDLembretes.DTO.UsuarioTarefasOficial
{
    public class UsuarioTarefasOficialDTO
    {
        public PrioridadeTarefa Prioridade { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public StatusTarefa Status { get; set; } 
        public string? ComprovacaoUrl { get; set; }

    }
}
