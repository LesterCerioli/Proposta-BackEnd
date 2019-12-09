namespace Propostas.Domain.Models
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    ///     Entidade TipoSecao.
    /// </summary>
    public class TipoSecao : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="TipoSecao"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public TipoSecao()
            : base()
        {
        }
        public TipoSecao(string nome, bool obrigatorio, string formato)
        {
            this.Nome = nome.ToTitleCase();
            this.Obrigatorio = true;
            this.Formato = formato;

        }

        #endregion Construtores

        #region Propriedades

        public string Nome { get; set; }
        public bool Obrigatorio { get; set; }
        public string Formato { get; set; }


        public virtual ICollection<Secao> Secoes { get; set; }
        #endregion Propriedades

    }
}