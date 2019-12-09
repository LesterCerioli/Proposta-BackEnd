namespace Propostas.Domain.Models
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    ///     Entidade Recurso.
    /// </summary>
    public class Recurso : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="Recurso"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public Recurso()
            : base()
        {
        }

        public Recurso(string nome)
        {
            this.Nome = nome.ToTitleCase();
           
        }

        #endregion Construtores

        #region Propriedades

        public string Nome { get; set; }
        
        #endregion Propriedades
    }
}
