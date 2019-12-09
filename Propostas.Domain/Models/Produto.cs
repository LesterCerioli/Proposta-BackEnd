namespace Propostas.Domain.Models
{
    /// <summary>
    ///     Entidade Produto.
    /// </summary>
    public class Produto : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="Produto"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public Produto()
            : base()
        {
        }

        #endregion Construtores

        #region Propriedades

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public int UnidadeMedidaId { get; set; }

        public UnidadeMedida UnidadeMedida { get; set; }

        #endregion Propriedades
    }
}
