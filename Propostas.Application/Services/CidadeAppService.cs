namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     Implementação da <see cref="ICidadeAppService"/>.
    /// </summary>
    public class CidadeAppService : BaseAppService<CidadeViewModel, CidadeFilter, Cidade>, ICidadeAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CidadeAppService"/> class.
        ///     Construtor padrão de <see cref="CidadeAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Cidade. Veja <see cref="ICidadeRepository"/>.
        /// </param>
        public CidadeAppService(
            IUnitOfWork uow,
            IMapper mapper,
            ICidadeRepository repository)
            : base(uow, mapper, repository)
        {
        }

        /// <summary>
        ///     Obtém a cidade cujo código do IBGE é o passado como parâmetro.
        /// </summary>
        /// <param name="codigo">
        ///     Código da cidade conforme a tabela do IBGE.
        /// </param>
        /// <returns>
        ///     Cidade View Model contendo o estado e o país que pertence a cidade.
        /// </returns>
        public CidadeViewModel GetByCodigoIbge(string codigo)
        {
            codigo = codigo.ReplaceNonDigits();
            if (string.IsNullOrEmpty(codigo))
            {
                throw new PropostasException("Código IBGE não informado.");
            }

            var cidade = this.repository.GetBy(c => c.CodigoIbge == int.Parse(codigo), c => c.Estado.Pais).FirstOrDefault();
            if (cidade == null)
            {
                throw new PropostasException("Cidade não encontrada.");
            }

            return this.mapper.Map<CidadeViewModel>(cidade);
        }

        /// <summary>
        ///     Obtém todas as cidades do estado informado.
        /// </summary>
        /// <param name="id">
        ///     Identificador do estado.
        /// </param>
        /// <returns>
        ///     Todas as cidades que são do estado informado.
        /// </returns>
        public IEnumerable<CidadeViewModel> GetByEstado(int id)
        {
            var results = this.repository.GetByOrdered(cid => cid.EstadoId == id, cid => cid.Nome, true).ToList();
            return this.mapper.Map<IEnumerable<CidadeViewModel>>(results);
        }
    }
}
