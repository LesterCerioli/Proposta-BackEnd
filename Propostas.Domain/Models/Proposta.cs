using System;
using System.Collections;
using System.Collections.Generic;

namespace Propostas.Domain.Models
{
    /// <summary>
    ///     Entidade Proposta.
    /// </summary>
    public class Proposta : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="Proposta"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public Proposta()
            : base()
        {
        }

        #endregion Construtores

        #region Propriedades

        public Guid Codigo { get; set; }
        public int Versao { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string DataPropostaAlteracao { get; set; }
        public string UrlArquivo { get; set; }
        
        public int TemplateId { get; set; }
        public virtual Template Template { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    
        public ICollection<PropostaTag> PropostaTags { get; set; }
        #endregion Propriedades
    }
}
