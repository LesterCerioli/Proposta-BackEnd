namespace Propostas.Domain.Models
{
    /// <summary>
    ///     Entidade PropostaTag.
    /// </summary>
    public class PropostaTag : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropostaTag"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public PropostaTag()
            : base()
        {
        }

        #endregion Construtores

        #region Propriedades

        #endregion Propriedades
        public int SecaoArquivoTagId { get; set; }
        public virtual SecaoArquivoTag SecaoArquivoTag { get; set; }

        public int PropostaId { get; set; }
        public virtual Proposta Proposta { get; set; }

        public string Valor { get; set; }

        public string Base64 { get; set; }
    }
}
