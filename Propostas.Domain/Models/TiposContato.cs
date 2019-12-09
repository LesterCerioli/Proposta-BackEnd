namespace Propostas.Domain.Models
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    ///     Entidade TiposContato.
    /// </summary>
    public class TiposContato : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="TiposContato"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public TiposContato()
            : base()
        {
        }
        public TiposContato(string nome)
        {
            this.Nome = nome.ToTitleCase();

        }

        #endregion Construtores

        #region Propriedades

        public string Nome { get; set; }

        public virtual ICollection<Contato> Contatos { get; set; }
        #endregion Propriedades
    }
}
