namespace TDLembretes.Models
{
    public class UsuarioTarefasOficiais
    {
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string TarefaOficialId { get; set; }
        public TarefaOficial TarefaOficial { get; set; }

        private UsuarioTarefasOficiais() { }

        public UsuarioTarefasOficiais(string usuarioId, Usuario usuario, string tarefaOficialId, TarefaOficial tarefaOficial)
        {
            UsuarioId = usuarioId;
            Usuario = usuario;
            TarefaOficialId = tarefaOficialId;
            TarefaOficial = tarefaOficial;
        }


    }
}
