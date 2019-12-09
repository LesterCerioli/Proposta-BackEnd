namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de Pais Application Service
    /// </summary>
    public interface IPaisAppService : IBaseAppService<PaisViewModel, PaisFilter, Pais>
    {
    }
}
