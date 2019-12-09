using System;

namespace Propostas.Domain.Models
{
    /// <summary>
    ///     Entidade Cidade.
    /// </summary>
    public class Cidade : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cidade"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public Cidade()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cidade"/> class.
        ///     Construtor padrão usado para ações de adição uma nova entidade no Banco de Dados.
        /// </summary>
        public Cidade(string nome, int codigoIbge, Estado estado)
            : base()
        {
            this.SetarCampos(nome, codigoIbge, estado, true);
        }
        
        public string Nome { get; private set; }

        public int CodigoIbge { get; private set; }

        public int EstadoId { get; private set; }

        public Estado Estado { get; private set; }
        
        #region Métodos

        /// <summary>
        ///     Seta todos os campos da Cidade.
        /// </summary>
        /// <param name="nome">
        ///     Nome da Cidade.
        /// </param>
        /// <param name="codigoIbge">
        ///     O número do código do IBGE para a Cidade.
        /// </param>
        /// <param name="estado">
        ///     Estado da Cidade.
        /// </param>
        /// <param name="ativo">
        ///     Indicador se a Cidade está ativa.
        /// </param>
        public void SetarCampos(string nome, int codigoIbge, Estado estado, bool ativo)
        {
            this.SetarNome(nome);
            this.SetarCodigoIbge(codigoIbge);
            this.SetarEstado(estado);
            this.SetarAtivo(ativo);
        }

        /// <summary>
        ///     Seta o nome da Cidade em TitleCase.
        /// </summary>
        /// <param name="nome">
        ///     Nome da Cidade.
        /// </param>
        public void SetarNome(string nome)
        {
            this.Nome = nome.ToTitleCase();
        }

        /// <summary>
        ///     Seta o número do código do IBGE da Cidade.
        /// </summary>
        /// <param name="codigoIbge">
        ///     O número do código do IBGE da Cidade.
        /// </param>
        public void SetarCodigoIbge(int codigoIbge)
        {
            this.CodigoIbge = codigoIbge;
        }

        /// <summary>
        ///     Seta o Estado da Cidade.
        /// </summary>
        /// <param name="estado">
        ///     Estado a ser setado.
        /// </param>
        public void SetarEstado(Estado estado)
        {
            this.EstadoId = estado.Id;
            this.Estado = estado;
        }

        #endregion Métodos
    }
}
