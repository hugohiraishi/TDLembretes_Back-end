namespace TDLembretes.Models
{
    public class TarefaPersonalizada
    {
        public String Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public StatusTarefa Status { get; set; } = StatusTarefa.Pendente; 
        public PrioridadeTarefa Prioridade { get; set; }


        private TarefaPersonalizada() { }

        public TarefaPersonalizada(string id, string titulo, string descricao, DateTime dataCriacao, DateTime dataFinalizacao, StatusTarefa status, PrioridadeTarefa prioridade)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = dataCriacao;
            DataFinalizacao = dataFinalizacao;
            Status = status; 
            Prioridade = prioridade;

        }

    }

    public enum StatusTarefa
    {
        Pendente,
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
