namespace Propostas.Domain.Models
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    ///     Entidade TipoTemplate.
    /// </summary>
    public class TipoTemplate : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="TipoTemplate"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public TipoTemplate()
            : base()
        {
        }
        public TipoTemplate(string nome)
        {
            this.Nome = nome.ToTitleCase();

        }
        #endregion Construtores

        #region Propriedades

        public string Nome { get; set; }
        #endregion Propriedades
    }
}
