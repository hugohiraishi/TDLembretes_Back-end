namespace TDLembretes.DTO.Compra
{
    public class ComprarRequest
    {
        public string UsuarioId { get; set; } = string.Empty;
        public string ProdutoId { get; set; } = string.Empty;
        public int Quantidade { get; set; }
    }

}
