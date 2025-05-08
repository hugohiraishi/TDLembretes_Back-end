namespace TDLembretes.Models
{
    public class UsuarioTarefasPersonalizadas
    {
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string TarefaPersonalizadaId { get; set; }
        public TarefaPersonalizada TarefaPersonalizada { get; set; }

        private UsuarioTarefasPersonalizadas() { }

        public UsuarioTarefasPersonalizadas (string usuarioId, Usuario usuario, string tarefaPersonalizadaId, TarefaPersonalizada tarefaPersonalizada)
        {
            UsuarioId = usuarioId;
            Usuario = usuario;
            TarefaPersonalizadaId = tarefaPersonalizadaId;
            TarefaPersonalizada = tarefaPersonalizada;
        }
    }
}
