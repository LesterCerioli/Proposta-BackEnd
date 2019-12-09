namespace Propostas.Domain.Models
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    ///     Entidade PerfilUsuario.
    /// </summary>
    public class PerfilUsuario : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="PerfilUsuario"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public PerfilUsuario()
            : base()
        {
        }
        public PerfilUsuario(string nome)
        {
            this.Nome = nome.ToTitleCase();
        }

        #endregion Construtores

        #region Propriedades

        public string Nome { get; set; }

        #endregion Propriedades
    }
}
