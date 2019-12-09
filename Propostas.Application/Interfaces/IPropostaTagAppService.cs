namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de PropostaTag Application Service
    /// </summary>
    public interface IPropostaTagAppService : IBaseAppService<PropostaTagViewModel, PropostaTagFilter, PropostaTag>
    {
    }
}
