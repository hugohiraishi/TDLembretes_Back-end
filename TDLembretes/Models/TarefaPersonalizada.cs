namespace TDLembretes.Models
{
    public class TarefaPersonalizada
    {
        public String Id { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public StatusTarefa Status { get; set; } = StatusTarefa.EmAndamento; 
        public PrioridadeTarefa Prioridade { get; set; }


        private TarefaPersonalizada() { }

        public TarefaPersonalizada(string id, string titulo, string descricao, DateTime dataCriacao, DateTime dataFinalizacao, StatusTarefa status, PrioridadeTarefa prioridade, string usuarioId)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = dataCriacao;
            DataFinalizacao = dataFinalizacao;
            Status = status; 
            Prioridade = prioridade;
            UsuarioId = usuarioId;

        }

    }

    public enum StatusTarefa
    {
        EmAndamento,
        Concluida,
        Expirada
    }

    public enum PrioridadeTarefa
    {
        Baixa,
        Media,
        Alta
    }

}
