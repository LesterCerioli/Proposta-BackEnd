namespace Propostas.Domain.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Entidade Pais.
    /// </summary>
    public class Pais : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pais"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public Pais()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pais"/> class.
        ///     Construtor padrão usado para ações de adição uma nova entidade no Banco de Dados.
        /// </summary>
        public Pais(string codigoBacen, string nome, bool tributacaoFavorecida, string codigo)
            : base()
        {
            this.SetarCampos(nome, codigo, codigoBacen, tributacaoFavorecida, true);
        }

        /// <summary>
        ///     O nome do país.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        ///     O código do país.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        ///     Código do Pais de acordo com o Banco Central do Brasil.
        /// </summary>
        /// <seealso cref="http://www.bcb.gov.br/rex/Censo2000/port/manual/pais.asp?idpai=censo2000inf"/>
        public string CodigoBacen { get; set; }

        private ICollection<Estado> estados;

        /// <summary>
        ///     A lista de estados que pertencem ao país.
        /// </summary>
        public ICollection<Estado> Estados
        {
            get { return this.estados ?? (this.estados = new List<Estado>()); }
            set { this.estados = value; }
        }

        /// <summary>
        ///     Seta os campos do país.
        /// </summary>
        public void SetarCampos(string nome, string codigo, string codigoBacen, bool tributacaoFavorecida, bool ativo)
        {
            this.SetarNome(nome);
            this.SetarCodigo(codigo);
            this.SetarCodigoBacen(codigoBacen);
            this.SetarAtivo(ativo);
        }

        /// <summary>
        ///     Seta o nome do país.
        /// </summary>
        public void SetarNome(string nome)
        {
            this.Nome = nome.ToTitleCase();
        }

        /// <summary>
        ///     Seta o código do país sempre em UpperCase.
        /// </summary>
        public void SetarCodigo(string codigo)
        {
            codigo = codigo ?? string.Empty;
            this.Codigo = codigo.ToUpper();
        }

        /// <summary>
        ///     Seta o código do país de acordo com o Banco Central do Brasil.
        /// </summary>
        public void SetarCodigoBacen(string codigoBacen)
        {
            codigoBacen = codigoBacen ?? string.Empty;
            this.CodigoBacen = codigoBacen.ReplaceNonDigits().PadLeft(4, '0');
        }
    }
}
