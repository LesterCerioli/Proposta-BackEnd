namespace Propostas.Domain.Models
{
    /// <summary>
    ///     Entidade TemplateSecao.
    /// </summary>
    public class TemplateSecao : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="TemplateSecao"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public TemplateSecao()
            : base()
        {
        }

        #endregion Construtores

        #region Propriedades

        public int TemplateId{ get; set; }
        public Template Template{ get; set; }
        
        public int SecaoId { get; set; }
        public Secao Secao { get; set; }

        #endregion Propriedades

    }
}
