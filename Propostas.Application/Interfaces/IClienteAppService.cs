namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de Cliente Application Service
    /// </summary>
    public interface IClienteAppService : IBaseAppService<ClienteViewModel, ClienteFilter, Cliente>
    {
    }
}
