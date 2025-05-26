namespace TDLembretes.Models
{
    public class UsuarioTarefasOficiais
    {

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public string TarefaOficialId { get; set; }
        public TarefaOficial TarefaOficial { get; set; }


        public PrioridadeTarefa Prioridade { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public StatusTarefa Status { get; set; } = StatusTarefa.EmAndamento;
        public string? ComprovacaoUrl { get; set; }
        public StatusComprovacao StatusComprovacao { get; set; } = StatusComprovacao.AguardandoAprovacao;

        private UsuarioTarefasOficiais() { }

        public UsuarioTarefasOficiais(string usuarioId, string tarefaOficialId)
        {
            UsuarioId = usuarioId;
            TarefaOficialId = tarefaOficialId;
        }
    }
}
