namespace Propostas.Application.ViewModels
{
    public class ProdutoViewModel : BaseViewModel
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public int UnidadeMedidaId { get; set; }

        public UnidadeMedidaViewModel UnidadeMedida { get; set; }
    }
}
