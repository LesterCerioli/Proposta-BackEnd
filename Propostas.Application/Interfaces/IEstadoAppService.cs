namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;
    using System.Collections.Generic;

    /// <summary>
    ///     Interface de contrato de Estado Application Service
    /// </summary>
    public interface IEstadoAppService : IBaseAppService<EstadoViewModel, EstadoFilter, Estado>
    {
        /// <summary>
        ///     Obtém todos os Estados do país informado.
        /// </summary>
        /// <param name="id">
        ///     Id do país.
        /// </param>
        /// <returns>
        ///     Todos os Estados do Banco de Dados. Veja See <see cref="EstadoViewModel"/>.
        /// </returns>
        IEnumerable<EstadoViewModel> GetByPais(int id);
    }
}
