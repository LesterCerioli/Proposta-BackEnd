namespace Propostas.Domain.Models
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    ///     Entidade Linguagem.
    /// </summary>
    public class Linguagem : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="Linguagem"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public Linguagem()
            : base()
        {
        }
        public Linguagem(string nome)
        {
            this.Nome = nome.ToTitleCase();
            
        }

        #endregion Construtores
        
        public string Nome { get; set; }

        public virtual ICollection<Secao> Secoes { get; set; }
     
    }
}
