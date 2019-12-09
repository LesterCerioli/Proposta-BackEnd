

using System.Collections.Generic;

namespace Propostas.Domain.Models
{
    /// <summary>
    ///     Entidade Cliente.
    /// </summary>
    public class Cliente : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="Cliente"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public Cliente()
            : base()
        {
        }
        public Cliente(string cnpj, string razaoSocial, string nomeFantasia)
        {
            this.CNPJ = cnpj;
            this.RazaoSocial = razaoSocial;
            this.NomeFantasia = nomeFantasia;

        }
        #endregion Construtores

        #region Propriedades

        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        public ICollection<Contato> Contatos { get; set; }
        public ICollection<Proposta> Propostas { get; set; }

        #endregion Propriedades
    }
}