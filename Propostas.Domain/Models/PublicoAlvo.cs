namespace Propostas.Domain.Models
{

    using System;
    using System.Collections.Generic;
    /// <summary>
    ///     Entidade PublicoAlvo.
    /// </summary>
    public class PublicoAlvo : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="PublicoAlvo"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public PublicoAlvo()
            : base()
        {
        }


        public PublicoAlvo(string nome)
        {
            this.Nome = nome.ToTitleCase();
        }

        #endregion Construtores

        #region Propriedades

        public string Nome { get; set; }
        public virtual ICollection<Secao> Secoes { get; set; }
        #endregion Propriedades
    }
}
