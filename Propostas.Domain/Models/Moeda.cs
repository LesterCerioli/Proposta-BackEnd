namespace Propostas.Domain.Models
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    ///     Entidade Moeda.
    /// </summary>
    public class Moeda : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="Moeda"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public Moeda()
            : base()
        {
        }
        public Moeda(string nome, string abreviacao)
        {
            this.Nome= nome.ToTitleCase();
        }

        #endregion Construtores

        #region Propriedades

        public string Nome { get; set; }

        #endregion Propriedades
    }
}
