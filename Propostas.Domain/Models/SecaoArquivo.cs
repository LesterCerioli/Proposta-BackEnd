using System;
using System.Collections.Generic;

namespace Propostas.Domain.Models
{
    public class SecaoArquivo : BaseEntity
    {
        public int SecaoId { get; set; }
        public Secao Secao { get; set; }

        public string Nome { get; set; }
        public string Base64Arquivo { get; set; }
        public string Url { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime Publicado { get; set; }
        public int? Versao { get; set; }

        private ICollection<SecaoArquivoTag> secaoArquivoTags;

        /// <summary>
        ///     A lista de e-mails que a pessoa possui.
        /// </summary>
        public ICollection<SecaoArquivoTag> SecaoArquivoTags
        {
            get { return this.secaoArquivoTags ?? (this.secaoArquivoTags = new List<SecaoArquivoTag>()); }
            set { this.secaoArquivoTags = value; }
        }
    }
}
