using System;
using System.Collections.Generic;
using System.Linq;

namespace Propostas.Domain.Models
{
    /// <summary>
    ///     Entidade Secao.
    /// </summary>
    public class Secao : BaseEntity
    {
        #region Construtores

        /// <summary>
        ///     Initializes a new instance of the <see cref="Secao"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public Secao()
            : base()
        {
        }
        public Secao(string nome, bool editavel, int linguagemId, int tipoSecaoId, int publicoAlvoId,int Ordem, DateTime dataAlteracao, string usuario)
        {
            //this.CNPJ = cnpj;
            //this.RazaoSocial = razaoSocial;
            //this.NomeFantasia = nomeFantasia;

        }
        #endregion Construtores

        #region Propriedades
        public string Nome { get; set; }
        public bool Editavel { get; set; }
        public int? LinguagemId { get; set; }
        public int? TipoSecaoId { get; set; }
        public int? PublicoAlvoId { get; set; }
        public int Ordem { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int? UsuarioAlteracaoId { get; set; }

        public virtual Linguagem Linguagem { get; set; }
        public virtual TipoSecao TipoSecao { get; set; }
        public virtual PublicoAlvo PublicoAlvo { get; set; }

        public virtual ICollection<SecaoArquivo> SecaoArquivo { set; get; }
        public virtual ICollection<TemplateSecao> TemplateSecoes { get; set; }
      
        public string GetNomeArquivo()
        {
            var secaoArquivoId = SecaoArquivo.FirstOrDefault(cons => cons.Ativo == true).Id;
            return $"secao_{Id}_{secaoArquivoId}.docx";
        }
        #endregion Propriedades
    }
}
