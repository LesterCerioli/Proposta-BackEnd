namespace Propostas.Domain.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Entidade Estado.
    /// </summary>
    public class Estado : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Estado"/> class.
        ///     Contrutor vazio utilizado pelo EntityFramework.
        /// </summary>
        public Estado()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Estado"/> class.
        ///     Construtor padrão usado para ações de adição uma nova entidade no Banco de Dados.
        /// </summary>
        /// <param name="nome">
        ///     O nome do Estado.
        /// </param>
        /// <param name="uf">
        ///     A unidade federativa do Estado.
        /// </param>
        /// <param name="codigoIbge">
        ///     O número do códgo do IBGE para o Estado.
        /// </param>
        /// <param name="pais">
        ///     O país onde o estado está localizado.
        /// </param>
        public Estado(string nome, string uf, int codigoIbge, Pais pais)
            : base()
        {
            this.SetarCampos(nome, uf, codigoIbge, pais, true);
        }

        /// <summary>
        ///     O nome do Estado.
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        ///     A unidade Federativa do Estado.
        /// </summary>
        public string Uf { get; private set; }

        /// <summary>
        ///     O número do código do IBGE do Estado.
        /// </summary>
        public int CodigoIbge { get; private set; }

        public int PaisId { get; private set; }

        public Pais Pais { get; private set; }

        private ICollection<Cidade> cidades;

        /// <summary>
        ///     A lista de Cidades que pertencem ao Estado.
        /// </summary>
        public ICollection<Cidade> Cidades
        {
            get { return this.cidades ?? (this.cidades = new List<Cidade>()); }
            set { this.cidades = value; }
        }

        public void SetarCampos(string nome, string uf, int codigoIbge, Pais pais, bool ativo)
        {
            this.SetarNome(nome);
            this.SetarUf(uf);
            this.SetarCodigoIbge(codigoIbge);
            this.SetarPais(pais);
            this.SetarAtivo(ativo);
        }

        /// <summary>
        ///     Seta o nome do Estado.
        /// </summary>
        public void SetarNome(string nome)
        {
            this.Nome = nome.ToTitleCase();
        }

        /// <summary>
        ///     Seta a Unidade Federativa (UF) do Estado sempre em UpperCase.
        /// </summary>
        public void SetarUf(string uf)
        {
            uf = uf ?? string.Empty;
            this.Uf = uf.ToUpper();
        }

        /// <summary>
        ///     Seta o número código do IBGE para o Estado.
        /// </summary>
        public void SetarCodigoIbge(int codigoIbge)
        {
            this.CodigoIbge = codigoIbge;
        }

        /// <summary>
        ///     Seta o país do Estado.
        /// </summary>
        /// <param name="pais"></param>
        public void SetarPais(Pais pais)
        {
            this.PaisId = pais.Id;
            this.Pais = pais;
        }
    }
}
