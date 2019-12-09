using System;
using System.Collections.Generic;

namespace Propostas.Domain.Models
{
    /// <summary>
    ///     Entidade Template.
    /// </summary>
    public class Template : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="Template"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public Template()
            : base()
        {
        }

        #endregion Construtores

        #region Propriedades
        public string Nome { get; set; }
        public int? Versao { get; set; }
        public int TipoTemplateId { get; set; }
        public TipoTemplate TipoTemplate{ get;set;}
        public Guid Codigo { get; set; }

        public ICollection<TemplateSecao> TemplateSecoes { get; set; }


        #endregion Propriedades
    }
}
