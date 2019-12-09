namespace Propostas.Domain.Models
{
    /// <summary>
    ///     Entidade SecaoArquivoTag.
    /// </summary>
    public class SecaoArquivoTag : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecaoArquivoTag"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public SecaoArquivoTag()
            : base()
        {
        }

        #endregion Construtores

        public int SecaoArquivoId { get; set; }
        public virtual SecaoArquivo SecaoArquivo { get; set; }

        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
        
        #region Propriedades

        #endregion Propriedades
    }
}
