namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;
    using System.Collections.Generic;

    /// <summary>
    ///     Interface de contrato de Cidade Application Service
    /// </summary>
    public interface ICidadeAppService : IBaseAppService<CidadeViewModel, CidadeFilter, Cidade>
    {
        /// <summary>
        ///     Obtém a cidade cujo código do IBGE é o passado como parâmetro.
        /// </summary>
        /// <param name="codigo">
        ///     Código da cidade conforme a tabela do IBGE.
        /// </param>
        /// <returns>
        ///     Cidade View Model contendo o estado e o país que pertence a cidade.
        /// </returns>
        CidadeViewModel GetByCodigoIbge(string codigo);

        /// <summary>
        ///     Obtém todas as cidades do estado informado.
        /// </summary>
        /// <param name="id">
        ///     Identificador do estado.
        /// </param>
        /// <returns>
        ///     Todas as cidades que são do estado informado.
        /// </returns>
        IEnumerable<CidadeViewModel> GetByEstado(int id);
    }
}
