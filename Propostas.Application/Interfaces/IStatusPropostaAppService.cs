namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de StatusProposta Application Service
    /// </summary>
    public interface IStatusPropostaAppService : IBaseAppService<StatusPropostaViewModel, StatusPropostaFilter, StatusProposta>
    {
    }
}
