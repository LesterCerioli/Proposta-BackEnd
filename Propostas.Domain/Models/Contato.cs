using System.Collections.Generic;

namespace Propostas.Domain.Models
{
    /// <summary>
    ///     Entidade Contato.
    /// </summary>
    public class Contato : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="Contato"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public Contato()
            : base()
        {
        }


        #endregion Construtores

        #region Propriedades
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Funcao { get; set; }

        public int ClienteId { get; set; }
        public int TipoContatoId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual TiposContato TiposContato { get; set; }
        #endregion Propriedades

    }
}
