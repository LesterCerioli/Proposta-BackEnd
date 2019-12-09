namespace Propostas.Domain.Models
{
    /// <summary>
    ///     Entidade Tag.
    /// </summary>
    public class Tag : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="Tag"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public Tag()
            : base()
        {
        }
        #endregion Construtores

        #region Propriedades

        public string Chave { get; set; }
        public string Tipo { get; set; }
        public bool   Especial { get; set; }
        #endregion Propriedades
    }
}
