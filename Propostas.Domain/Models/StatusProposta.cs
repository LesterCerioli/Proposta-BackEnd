namespace Propostas.Domain.Models
{

    using System;
    using System.Collections.Generic;
    /// <summary>
    ///     Entidade StatusProposta.
    /// </summary>
    public class StatusProposta : BaseEntity
    {

        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="StatusProposta"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public StatusProposta()
            : base()
        {
        }

        public StatusProposta(string nome)
        {
            this.Nome = nome.ToTitleCase();

        }
        #endregion Construtores

        #region Propriedades

        public string Nome { get; set; }
        #endregion Propriedades
    }
}
