namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de UnidadeMedida Application Service
    /// </summary>
    public interface IUnidadeMedidaAppService : IBaseAppService<UnidadeMedidaViewModel, UnidadeMedidaFilter, UnidadeMedida>
    {
    }
}
